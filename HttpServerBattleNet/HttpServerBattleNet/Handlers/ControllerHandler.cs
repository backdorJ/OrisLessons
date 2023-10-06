using System.Net;
using System.Reflection;
using HttpServerBattleNet.Attribuets;

namespace HttpServerBattleNet.Handler;

public class ControllerHandler : Handler
{
    public override void HandleRequest(HttpListenerContext context)
    {
        try
        {
            var strParams = context?.Request.Url!
                .Segments
                .Skip(1)
                .Select(s => s.Replace("/", ""))
                .ToArray();
            
            if (strParams!.Length < 2)
                throw new ArgumentNullException("the number of lines in the query string is less than two!");
        
            using var streamReader = new StreamReader(context!.Request.InputStream);
            var tempOfData = streamReader.ReadToEnd();
            string[] formData = new[]{""};
            if (!String.IsNullOrEmpty(tempOfData))
            {
                var currentOfUserData = tempOfData?.Split('&');
                formData = new string[]{WebUtility.UrlDecode(currentOfUserData[0][6..]), currentOfUserData[1][9..]};   
            }
        
            var controllerName = strParams[0];
            var methodName = strParams[1];
            var assembly = Assembly.GetExecutingAssembly();
    
            var controller = assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(ControllerAttribute)))
                .FirstOrDefault(c => ((ControllerAttribute)Attribute.GetCustomAttribute(c, typeof(ControllerAttribute))!)
                    .ControllerName.Equals(controllerName, StringComparison.OrdinalIgnoreCase));

            var list = controller?.GetMethods()
                .Select(method => new { Name = method.Name, Attributes = method.GetCustomAttributes()});

            var method = controller?.GetMethods()
                .Where(x => x.GetCustomAttributes(true)
                    .Any(attr => attr.GetType().Name.Equals($"{context.Request.HttpMethod}Attribute",
                        StringComparison.OrdinalIgnoreCase)))
                .FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));
            
            var queryParams = new object[]{};
            
            if(formData.Length > 1)
            {            
                queryParams = method?.GetParameters()
                .Select((p, i) => Convert.ChangeType(formData[i], p.ParameterType))
                .ToArray();
            }
            
            method?.Invoke(Activator.CreateInstance(controller), queryParams);   
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
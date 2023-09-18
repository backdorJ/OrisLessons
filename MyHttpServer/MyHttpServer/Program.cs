using System.Net;
using System.Text;
using MyHttpServer;
using Newtonsoft.Json;
using HttpListener = System.Net.HttpListener;

class Program
{
    private const string PATH_CONFIGURATION = "appsettings.json";
    static async Task Main()
    {
        // try
        // {
        //     if (!File.Exists(PATH_CONFIGURATION))
        //     {
        //         Console.WriteLine("Файл appsettings.json не найден");
        //         throw new FileNotFoundException();
        //     }
        //     
        //     var strJson = await File.OpenText(PATH_CONFIGURATION).ReadToEndAsync();
        //     var config = JsonConvert.DeserializeObject<AppSettingsConfig>(strJson);
        //     
        //     
        //      using var httpListener = new HttpListener();
        //      httpListener.Prefixes.Add($"http://{config.Address}:{config.Port}/");
        //      httpListener.Start();
        //      Console.WriteLine("Serves has started");
        //     
        //      while (true)
        //      {
        //          var context = await httpListener.GetContextAsync();
        //          context.Response.ContentType = "text/html; charset=utf-8";
        //          using var response = context.Response;
        //     
        //          var buffer = await File.ReadAllBytesAsync("index.html");
        //          response.ContentLength64 = buffer.Length;
        //          
        //          await using var output = response.OutputStream;
        //     
        //          await output.WriteAsync(buffer);
        //          await output.FlushAsync();
        //      }
        // }
        // catch (FileNotFoundException e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        // }

        var server = new HttpServer();
        await server.Start();
    }   
}
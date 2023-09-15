using System.Net;
using System.Text;

class Program
{
    static async Task Main()
    {
        using var httpListener = new HttpListener();
        httpListener.Prefixes.Add("http://127.0.0.1:2020/");
        httpListener.Start();
        Console.WriteLine("Serves has started");
        var stoppedServer = false;
        
        while (true)
        {
            var context = await httpListener.GetContextAsync();
            context.Response.ContentType = "text/html; charset=utf-8";
            using var response = context.Response;

            var sr = new StreamReader(File.OpenRead("/home/ebet/Tasks/MyHttpServer/MyHttpServer/index.html"));
            var responseSite = await sr.ReadToEndAsync();

            var buffer = Encoding.UTF8.GetBytes(responseSite);
            response.ContentLength64 = buffer.Length;
            
            await using var output = response.OutputStream;

            await output.WriteAsync(buffer);
            await output.FlushAsync();

            Console.WriteLine("Enter if you want a stop server.");
            if (Console.ReadLine() != "stop".ToLower()) continue;
            httpListener.Stop();
            Console.WriteLine("Server has been stopped.");
            break;
        }
    }
}
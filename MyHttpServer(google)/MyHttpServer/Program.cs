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
        var server = new HttpServer();
        await server.Start();
    }   
}
using HttpServer;

class Program
{
    private static void Main()
    {
        var server = new MyHttpServer();
        server.Start();
        Console.ReadKey();
    }
}
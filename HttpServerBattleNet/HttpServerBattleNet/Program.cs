using HttpServerBattleNet;

class Program
{
    private static void Main()
    {
        var server = new HttpServer();
        server.Start();
        Console.ReadKey();
    }
}
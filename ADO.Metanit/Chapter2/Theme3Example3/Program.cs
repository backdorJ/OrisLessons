// See https://aka.ms/new-console-template for more information
//
//  Асинхронное подключение
//

using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        ConnectWithDB().GetAwaiter();
    }
 
    private static async Task ConnectWithDB()
    {
        var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";
 
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync();
            Console.WriteLine("Подключение открыто");
        }
        Console.WriteLine("Подключение закрыто...");
    }
}
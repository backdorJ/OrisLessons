// See https://aka.ms/new-console-template for more information
//
// Получение информации о подключении
//


using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";
using (var connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    Console.WriteLine("Подключение открыто");
 
    // Вывод информации о подключении
    Console.WriteLine("Свойства подключения:");
    Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
    Console.WriteLine("\tБаза данных: {0}", connection.Database);
    Console.WriteLine("\tСервер: {0}", connection.DataSource);
    Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
    Console.WriteLine("\tСостояние: {0}", connection.State);
}
Console.WriteLine("Подключение закрыто...");

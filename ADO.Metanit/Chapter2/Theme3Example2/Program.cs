// See https://aka.ms/new-console-template for more information

///
///
/// 2 пример с использованием using
/// 

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";

using var sqlConnection = new NpgsqlConnection(connectionString);
{
    sqlConnection.Open();
    Console.WriteLine("Подключение открыто!");
}
Console.WriteLine("Подключение закрыто!");
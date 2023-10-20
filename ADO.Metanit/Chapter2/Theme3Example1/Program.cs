///
/// Создание подключения Глава 2 Пример 1

using System.Data.SqlTypes;
using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";

var connection = new NpgsqlConnection(connectionString);
try
{
    connection.Open();
    Console.WriteLine("Подключение открыто");
}
catch (SqlTypeException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    connection.Close();
    Console.WriteLine("Подключение закрыто...");
}
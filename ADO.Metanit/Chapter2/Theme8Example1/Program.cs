// See https://aka.ms/new-console-template for more information
///
/// Получение скалярных значений
/// Пример 1
/// 

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var sqlExpression = "SELECT COUNT(*) FROM \"Clients\"";
using var sqlConnection = new NpgsqlConnection(connectionString);
sqlConnection.Open();
var command = new NpgsqlCommand(sqlExpression, sqlConnection);
var count = command.ExecuteScalar();

command.CommandText = "SELECT MIN(age) FROM \"Clients\"";
var min = command.ExecuteScalar();

Console.WriteLine("Count clients: {0}", count);
Console.WriteLine("Min age client: {0}", min);
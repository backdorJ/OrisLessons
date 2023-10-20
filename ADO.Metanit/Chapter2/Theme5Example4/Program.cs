// See https://aka.ms/new-console-template for more information
// Обновление объетов

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var sqlExpression = "UPDATE \"Clients\" SET Age=26 where id = 2;";
using var sqlConnection = new NpgsqlConnection(connectionString);
sqlConnection.Open();
var command = new NpgsqlCommand(sqlExpression, sqlConnection);
var number = command.ExecuteNonQuery();
Console.WriteLine("Обновлено объектов: {0}", number);

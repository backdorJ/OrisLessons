// See https://aka.ms/new-console-template for more information
// Уадление объектов

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var sqlExpression = "DELETE FROM \"Clients\" WHERE id = 2";
using var sqlConnection = new NpgsqlConnection(connectionString);
sqlConnection.Open();
var command = new NpgsqlCommand(sqlExpression, sqlConnection);
var number = command.ExecuteNonQuery();
Console.WriteLine("Delete {0} object", number);
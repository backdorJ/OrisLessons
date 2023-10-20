// See https://aka.ms/new-console-template for more information
///
/// Тема 5 приммер 1 Выполнение команд и SqlCommand
///
/// 

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";

using var sqlConnection = new NpgsqlConnection(connectionString);
sqlConnection.Open();
var command = new NpgsqlCommand();
command.CommandText = "Select * from Clients";
command.Connection = sqlConnection;
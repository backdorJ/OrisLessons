// See https://aka.ms/new-console-template for more information
///
/// Тема 4 Первый пример
/// 

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";
NpgsqlConnection connection;
connection = new(connectionString);
connection.Open();

Console.WriteLine(connection.ProcessID);
connection.Close();

connection.Open();
Console.WriteLine(connection.ProcessID);
connection.Close();
// See https://aka.ms/new-console-template for more information
///
/// Параметризация запросов
///
///  

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var name = "T',10);INSERT INTO \"Clients\" (Name, Age) VALUES('H";
var age = 19;
var sqlExpression = "INSERT INTO \"Clients\" (id, full_name, age) values(2,@name, @age);";
using var sqlConnection = new NpgsqlConnection(connectionString);
sqlConnection.Open();
var command = new NpgsqlCommand(sqlExpression, sqlConnection);
var nameParam = new NpgsqlParameter("@name", name);
var ageParam = new NpgsqlParameter("@age", age);
command.Parameters.Add(nameParam);
command.Parameters.Add(ageParam);
var number = command.ExecuteNonQuery();
Console.WriteLine("Insert {0} object", number);

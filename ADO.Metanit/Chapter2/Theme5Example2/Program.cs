// See https://aka.ms/new-console-template for more information
// 2 пример как можно сократить запись

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";
var sqlExpression = "Select * from Clients";
using var sql = new NpgsqlConnection(connectionString);
sql.Open();
var command = new NpgsqlCommand(sqlExpression, sql);

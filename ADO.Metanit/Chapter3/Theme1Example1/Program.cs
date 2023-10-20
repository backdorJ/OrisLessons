
///
/// Работа с SqlDataAdapter и DataSet
///

using System.Data;
using Npgsql;

string connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var sql = "SELECT * FROM \"Clients\";";
using var connection = new NpgsqlConnection(connectionString);

connection.Open();
var adapter = new NpgsqlDataAdapter(sql, connection);
var dataSet = new DataSet();
adapter.Fill(dataSet);
var table = dataSet.Tables[0];
foreach (DataRow row in table.Rows)
{
    foreach (var item in row.ItemArray)
    {
        Console.WriteLine(item);
    }
}
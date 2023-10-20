// See https://aka.ms/new-console-template for more information

using Npgsql;

string connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
using var connection = new NpgsqlConnection(connectionString);
connection.Open();

var transaction = connection.BeginTransaction();
var command = connection.CreateCommand();
command.Transaction = transaction;

try
{
    command.CommandText =
        "INSERT INTO \"Clients\" VALUES(6,0,'Башмачкин Башмак Башмачков', 20, '89871854613',false,false)";

    command.ExecuteNonQuery();
    
    command.CommandText =
        "INSERT INTO \"Clients\" VALUES(7,0,'Георгий Гера Герасимов', 25, '89871854613',false,false)";

    command.ExecuteNonQuery();
    transaction.Commit();
    Console.WriteLine("Данные добавлены!");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    transaction.Rollback();
}
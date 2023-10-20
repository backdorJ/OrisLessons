// See https://aka.ms/new-console-template for more information

using System.Data;
using Npgsql;
using NpgsqlTypes;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var age = 23;
var name = "Олег Олегович Олежкин";
var sqlExpression = "INSERT INTO \"Clients\" (full_name, age)";
using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
    // создаем параметр для имени
    NpgsqlParameter nameParam = new NpgsqlParameter("@name", name);
    // добавляем параметр к команде
    command.Parameters.Add(nameParam);
    // создаем параметр для возраста
    NpgsqlParameter ageParam = new NpgsqlParameter("@age", age);
    // добавляем параметр к команде
    command.Parameters.Add(ageParam);
    // параметр для id
    NpgsqlParameter idParam = new NpgsqlParameter
    {
        ParameterName = "@id",
        NpgsqlDbType = NpgsqlDbType.Integer,
        Direction = ParameterDirection.Output // параметр выходной
    };
    command.Parameters.Add(idParam);
     
    command.ExecuteNonQuery();
     
    // получим значения выходного параметра
    Console.WriteLine("Id нового объекта: {0}", idParam.Value);
}
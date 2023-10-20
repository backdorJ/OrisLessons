// See https://aka.ms/new-console-template for more information
// Типизация результатов SqlDataReader
// 1 пример

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var sqlExpression = "SELECT * FROM \"Clients\";";

using var sqlConnection = new NpgsqlConnection(connectionString);
sqlConnection.Open();
var command = new NpgsqlCommand(sqlExpression, sqlConnection);
var reader = command.ExecuteReader();

if (reader.HasRows)
{
    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
        reader.GetName(0),
        reader.GetName(1),reader.GetName(2),reader.GetName(3),
        reader.GetName(4),reader.GetName(5), reader.GetName(6));

    while (reader.Read())
    {
        var id = reader.GetInt32(0);
        var status = reader.GetInt32(1);
        var fullName = reader.GetString(2);
        var age = reader.GetInt32(3);
        var phoneNumber = reader.GetString(4);
        var isBlocked = reader.GetBoolean(5);
        var isAnonimus = reader.GetBoolean(6);

        Console.WriteLine("Id: {0}, Status: {1}, Full name: {2}, Age: {3}, Phone number: {4}, IsBlocked: {5}, IsAnonimys: {6}",
            id,status, fullName, age,phoneNumber,isBlocked, isAnonimus);
    }
}
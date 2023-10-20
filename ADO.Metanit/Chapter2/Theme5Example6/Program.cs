// See https://aka.ms/new-console-template for more information
// Пример со всеми вида CRUD операциями

using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
Console.WriteLine("Enter your full name: ");
var fullName = Console.ReadLine();

Console.WriteLine("Enter yout status");
var status = int.Parse(Console.ReadLine());

Console.WriteLine("Enter your age");
var age = int.Parse(Console.ReadLine());

Console.WriteLine("Enter your phone number");
var phoneNumber = Console.ReadLine();

var sqlExpression = $"insert into \"Clients\" values(5,'{status}', '{fullName}',{age}, '{phoneNumber}', false,false);";
var sqlConnection = new NpgsqlConnection(connectionString);
sqlConnection.Open();
var command = new NpgsqlCommand(sqlExpression, sqlConnection);
var number = command.ExecuteNonQuery();
Console.WriteLine("Insert new object!");

Console.WriteLine("Enter your new name");
var newName = Console.ReadLine();
sqlExpression = $"UPDATE \"Clients\" set full_name = '{newName}' where age = {age}";
command.CommandText = sqlExpression;
var number2 = command.ExecuteNonQuery();
Console.WriteLine("Update your name! {0}", number2);
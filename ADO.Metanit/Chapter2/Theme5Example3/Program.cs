// See https://aka.ms/new-console-template for more information
// ДОБАВЛЕНИЕ ОБЪЕКТОВ
using Npgsql;

var status = StatesClient.Platinum;
var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
var sqlExpression =
    $"insert into \"Clients\" (status, full_name, age, phone_number, isblocked, isanonymous)\nvalues (0, 'Набиуллин Дамир Рафаэлевич', 19, '89871854613',false, false);";
using var sql = new NpgsqlConnection(connectionString);
sql.Open();
var command = new NpgsqlCommand(sqlExpression, sql);
var number = command.ExecuteNonQuery();
Console.WriteLine("Добавелно объектов! {0}", number);


public enum StatesClient
{
    VIP,
    Platinum,
    Standart
}
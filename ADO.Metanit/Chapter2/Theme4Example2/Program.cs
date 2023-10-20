// See https://aka.ms/new-console-template for more information
///
/// 2 Пример который показывает что если строки подклдючений разные то и пул подключений другой
///
/// 


using Npgsql;

var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub;";
var connectioString2 = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub2;";

using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open(); // создается первый пул
    Console.WriteLine(connection.ProcessID);
}

using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    connection.Open(); // подключение извлекается из первого пула
    Console.WriteLine(connection.ProcessID);
}

using (NpgsqlConnection connection = new NpgsqlConnection(connectioString2))
{
    connection.Open(); // создается второй пул, т.к. строка подключения отличается
    Console.WriteLine(connection.ProcessID);
}
// See https://aka.ms/new-console-template for more information
// Асинхронное чтение из базы данных 2 пример

using Npgsql;

class Program
{
    static async Task Main(string[] args)
    {
        await ReadDataAsync();
    }

    static async Task ReadDataAsync()
    {
        var connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
 
        string sqlExpression = "SELECT * FROM \"Clients\";";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync();
            var command = new NpgsqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();
 
            if (reader.HasRows)
            {
                // выводим названия столбцов
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                    reader.GetName(0),
                    reader.GetName(1),reader.GetName(2),reader.GetName(3),
                    reader.GetName(4),reader.GetName(5), reader.GetName(6));
            
                while (await reader.ReadAsync())
                {
                    var id = reader.GetValue(0);
                    var status = reader.GetValue(1);
                    var fullName = reader.GetValue(2);
                    var age = reader.GetValue(3);
                    var phoneNumber = reader.GetValue(4);
                    var isBlocked = reader.GetValue(5);
                    var isAnonimus = reader.GetValue(6);

                    Console.WriteLine("Id: {0}, Status: {1}, Full name: {2}, Age: {3}, Phone number: {4}, IsBlocked: {5}, IsAnonimys: {6}",
                        id,status, fullName, age,phoneNumber,isBlocked, isAnonimus);
                }
            }
            reader.Close();
        }
    }   
}
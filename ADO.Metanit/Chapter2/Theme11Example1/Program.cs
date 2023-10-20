// See https://aka.ms/new-console-template for more information
// Процедуры

using Npgsql;

class Program
{
    static string connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
    static void Main(string[] args) 
    {
        Console.WriteLine("Введите ваш статус");
        var status = int.Parse(Console.ReadLine());
        
        Console.Write("Введите ваше полное имя:");
        var name = Console.ReadLine();
 
        Console.Write("Введите возраст пользователя:");
        var age = Int32.Parse(Console.ReadLine());
        
        Console.Write("Введите номер телефона:");
        var phone = Console.ReadLine();
 
        AddUser(status, name, age, phone);
        Console.WriteLine();
        //GetUsers();
 
        Console.Read();
    }
    // добавление пользователя
    private static void AddUser(int status, string name, int age, string phone)
    {
        // название процедуры
        string sqlExpression = "insertclients"; 
 
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
            // указываем, что команда представляет хранимую процедуру
            command.CommandType = System.Data.CommandType.StoredProcedure;

            NpgsqlParameter statusParam = new NpgsqlParameter
            {
                ParameterName = "@status",
                Value = status
            };
            command.Parameters.Add(statusParam);
            // параметр для ввода имени
            NpgsqlParameter nameParam = new NpgsqlParameter
            {
                ParameterName = "@name",
                Value = name
            };
            // добавляем параметр
            command.Parameters.Add(nameParam);
            // параметр для ввода возраста
            NpgsqlParameter ageParam = new NpgsqlParameter
            {
                ParameterName = "@age",
                Value = age
            };
            command.Parameters.Add(ageParam);
            
            NpgsqlParameter phoneParam = new NpgsqlParameter
            {
                ParameterName = "@phone",
                Value = phone
            };
 
            command.Parameters.Add(phoneParam);
            
            // если нам не надо возвращать id
            var result = command.ExecuteNonQuery();
 
            Console.WriteLine("Id добавленного объекта: {0}", result);
        }
    }
 
    // вывод всех пользователей
    // private static void GetUsers()
    // {
    //     // название процедуры
    //     string sqlExpression = "sp_GetUsers";
    //
    //     using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
    //     {
    //         connection.Open();
    //         NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
    //         // указываем, что команда представляет хранимую процедуру
    //         command.CommandType = System.Data.CommandType.StoredProcedure;
    //         var reader = command.ExecuteReader();
    //
    //         if (reader.HasRows)
    //         {
    //             Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
    //
    //             while (reader.Read())
    //             {
    //                 int id = reader.GetInt32(0);
    //                 string name = reader.GetString(1);
    //                 int age = reader.GetInt32(2);
    //                 Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
    //             }
    //         }
    //         reader.Close();
    //     }
    //}
}
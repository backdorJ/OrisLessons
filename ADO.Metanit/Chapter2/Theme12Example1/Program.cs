// See https://aka.ms/new-console-template for more information

using System.Data;
using Npgsql;
using NpgsqlTypes;

///
///
///
/// Выходные параметры хранимых процедур

class Program
    {
        static string connectionString = "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";
        static void Main(string[] args) 
        {
            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();
 
            GetAgeRange(name);
 
            Console.Read();
        }
 
        private static void GetAgeRange(string name)
        {
            string sqlExpression = "sp_GetAgeRange";
 
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
 
                NpgsqlParameter nameParam = new NpgsqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                command.Parameters.Add(nameParam);
 
                // определяем первый выходной параметр
                NpgsqlParameter minAgeParam = new NpgsqlParameter
                {
                    ParameterName = "@minAge",
                    NpgsqlDbType = (NpgsqlDbType)SqlDbType.Int // тип параметра
                };
                // указываем, что параметр будет выходным
                minAgeParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(minAgeParam);
 
                // определяем второй выходной параметр
                NpgsqlParameter maxAgeParam = new NpgsqlParameter
                {
                    ParameterName = "@maxAge",
                    NpgsqlDbType = (NpgsqlDbType)SqlDbType.Int
                };
                maxAgeParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(maxAgeParam);
 
                command.ExecuteNonQuery();
 
                Console.WriteLine("Минимальный возраст: {0}", command.Parameters["@minAge"].Value);
                Console.WriteLine("Максимальный возраст: {0}", command.Parameters["@maxAge"].Value);
            }
        }
    }
using System.Data;
using System.Reflection;
using System.Text;
using Npgsql;

namespace MyORM;

public class MyDataContext : IDatabaseOperation
{
    private string ConnectionString =>
        "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";

    ///  bool ADD<T>() - method - 1 row only [+]
    ///  bool Update<T>()
    ///  bool Delete<T>(id)
    ///  List<T> Select<T>()
    ///  T SelectById<T>()
    private NpgsqlConnection _connection;

    public bool Add<T>(T entity)
    {
        var type = entity?.GetType();
        var props = type?.GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(prop => !(prop.Name.Equals("id", StringComparison.OrdinalIgnoreCase)))
            .ToList();

        var tableName = type?.Name;

        var sb = new StringBuilder();
        var listOfArgs = new List<NpgsqlParameter>();

        sb.AppendFormat("insert into \"{0}\" (", tableName);

        foreach (var prop in props)
        {
            sb.Append($"\"{prop.Name}\",");
        }

        sb.Length--;
        sb.Append(") values (");

        foreach (var prop in props)
        {
            var paramName = $"@{prop.Name}";
            sb.Append($"{paramName},");
            listOfArgs.Add(new NpgsqlParameter(paramName, prop.GetValue(entity)));
        }

        sb.Length--;
        sb.Append(");");

        var command = new NpgsqlCommand(sb.ToString());
        command.Parameters.AddRange(listOfArgs.ToArray());

        return QueryToDatabase(command);
    }

    public bool Update<T>(T entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete<T>(int id)
    {
        throw new NotImplementedException();
    }

    public List<T> Select<T>(T entity)
    {
        throw new NotImplementedException();
    }

    public T SelectById<T>(int id)
    {
        throw new NotImplementedException();
    }

    private bool QueryToDatabase(NpgsqlCommand command)
    {
        using (_connection = new NpgsqlConnection(ConnectionString))
        {
            _connection.Open();
            command.Connection = _connection;
            var number = command.ExecuteNonQuery();
            Console.WriteLine("Update {0} object", number);
            return true;
        }
    }
}
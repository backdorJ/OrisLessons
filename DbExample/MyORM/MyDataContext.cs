﻿using System.Data;
using System.Reflection;
using System.Text;
using Npgsql;

namespace MyORM;

public class MyDataContext : IDatabaseOperation
{
    private NpgsqlConnection _connection;
    
    private string ConnectionString =>
        "Username=damirka20041;Password=root;Host=localhost;Port=5432;Database=StripClub";

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
        var type = typeof(T);
        var tableName = type.Name;

        var sqlExpression = $"DELETE FROM \"{tableName}\" WHERE \"id\" = {id} ";
        using (_connection = new NpgsqlConnection(ConnectionString))
        {
            _connection.Open();
            var command = new NpgsqlCommand(sqlExpression, _connection);
            var number = command.ExecuteNonQuery();
            Console.WriteLine("Delete {0} object by id: {1}", number, id);
            return true;
        }
    }

    public List<T> Select<T>(T entity)
    {
        var type = entity?.GetType();
        var tableName = type?.Name;

        var sqlExpression = $"SELECT * FROM \"{tableName}\"";
        using (_connection = new NpgsqlConnection(ConnectionString))
        {
            _connection.Open();
            var adapter = new NpgsqlDataAdapter(sqlExpression, _connection);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            var listOfTableItems = dataSet.Tables[0];
            var listOfEntities = new List<T>();
            
            foreach (DataRow row in listOfTableItems.Rows)
            {
                var objOfEntity = Activator.CreateInstance<T>();
                foreach (DataColumn column in listOfTableItems.Columns)
                {
                    var prop = type.GetProperty(column.ColumnName);
                    if (prop != null && row[column] != DBNull.Value)
                        prop.SetValue(objOfEntity, row[column]);
                }
                listOfEntities.Add(objOfEntity);
            }

            return listOfEntities;
        }
    }

    public T SelectById<T>(int id)
    {
        var tableName = typeof(T).Name;
        var type = typeof(T);
        var sqlExpression = $"SELECT * FROM \"{tableName}\"" +
                            $"WHERE \"id\" = {id} ";
        using (_connection = new NpgsqlConnection(ConnectionString))
        {
            _connection.Open();
            var adapter = new NpgsqlDataAdapter(sqlExpression, _connection);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            var listOfArgs = dataSet.Tables[0];
            
            foreach (DataRow row in listOfArgs.Rows)
            {
                var entity = Activator.CreateInstance<T>();
                foreach (DataColumn column in listOfArgs.Columns)
                {
                    var prop = type.GetProperty(column.ColumnName);
                    if (prop != null && row[column] != DBNull.Value)
                    {
                        prop.SetValue(entity, row[column]);
                    }
                }

                return entity;
            }
        }

        return default(T);
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
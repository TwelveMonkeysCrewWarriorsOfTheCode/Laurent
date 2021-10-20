using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADOLibrary
{
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TEntity> ExecuteReader<TEntity>(Command cmd, Func<SqlDataReader, TEntity> convert)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(cmd, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return convert(reader);
                        }
                    }
                }
            }
        }

        public object ExecuteScalar(Command cmd)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(cmd, connection))
                {
                    connection.Open();
                    Object Obj = command.ExecuteScalar();
                    return (Obj is DBNull) ? null : Obj;
                }
            }
        }

        public int ExecuteNonQuery(Command cmd)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(cmd, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        private SqlConnection CreateConnection() => new(_connectionString);

        private static SqlCommand CreateCommand(Command cmd, SqlConnection connection)
        {
            SqlCommand sqlCmd = connection.CreateCommand();
            sqlCmd.CommandText = cmd._query;
            sqlCmd.CommandType = cmd._isStoredProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;
            if (!(cmd._parameters is null))
            {
                foreach (KeyValuePair<string, object> param in cmd._parameters)
                {
                    SqlParameter parameter = sqlCmd.CreateParameter();
                    parameter.ParameterName = param.Key;
                    parameter.Value = param.Value;

                    sqlCmd.Parameters.Add(parameter);
                }
            }
            return sqlCmd;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopManager.DAL.Concrete.SQL
{
    internal class SqlCommandWrapper
    {
        private readonly string _connectionString;

        public SqlCommandWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object ExecuteReader<T>(string spName, SqlParameter[] parameters, Func<SqlDataReader, T> callback)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(spName, connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    command.CommandTimeout = 0;
                    var reader = command.ExecuteReader();
                    object result;
                    using (reader)
                    {
                        var list = new List<T>();
                        while (reader.Read())
                        {
                            var item = callback(reader);
                            if (!Equals(item, default(T)))
                            {
                                list.Add(item);
                            }
                        }

                        result = list;
                    }
                    return result;
                }
            }
        }

        public void ExecuteNoneQuery(string spName, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(spName, connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();

                }
            }
        }

        public object ExecuteReaderWithoutParamsAndCallback(CommandType commandType,string commandText)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(commandText, connection) { CommandType = CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.CommandTimeout = 0;

                    var result = command.ExecuteReader();

                    return null;
                }
            }
        }

        public object ExecuteReaderOneRow<T>(string spName, SqlParameter[] parameters, Func<SqlDataReader, T> callback)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(spName, connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                   connection.Open();
                    command.CommandTimeout = 0;
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        
                       if(reader.Read())
                        {
                            var item = callback(reader);
                            if (!Equals(item, default(T)))
                            {
                                return item;
                            }
                        }
                        return null;
                    }
                }
            }
        }

        public bool ExecuteNoneQueryMoreOneRecord(string spName, IEnumerable<SqlParameter[]> parameters)
        {
            List<SqlCommand> commandList=new List<SqlCommand>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int counter = 0;
                connection.Open();
                SqlTransaction tx = null;
                try
                {
                    tx = connection.BeginTransaction();
                    foreach (var item in parameters)
                    {
                        commandList.Add(new SqlCommand(spName, connection) {CommandType= CommandType.StoredProcedure });
                        commandList[counter].Parameters.AddRange(item);
                        commandList[counter].Transaction = tx;
                        counter++;
                    }
                    //Tranzaction:
                    for(int i =0; i<counter;i++)
                    {
                        commandList[i].ExecuteNonQuery();
                    }
                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    return false;
                }
            }
        }

    }

}

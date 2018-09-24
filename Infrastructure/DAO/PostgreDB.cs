using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Threading.Tasks;
using Npgsql;

namespace NutritionApi.Infrastructure.DAO
{
    public class PostgreDB
    {
        private readonly PostgreConnection postgreConnection;
        public PostgreDB()
        {
            postgreConnection = new PostgreConnection();
        }

        public async Task<List<T>> ExecuteQueryAsync<T>(String query, List<NpgsqlParameter> parameters, CommandType type)
        {
            try 
            {
                NpgsqlCommand cmd = postgreConnection.Connection.CreateCommand();
                cmd.CommandType = type;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters.ToArray());
                await postgreConnection.Connection.OpenAsync();
                DbDataReader dr = await cmd.ExecuteReaderAsync();
                List<T> list = new List<T>();
                T obj = default(T);
                while (await dr.ReadAsync()) {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties()) {
                        if (!object.Equals(dr[prop.Name], DBNull.Value)) {
                            prop.SetValue(obj, Convert.ChangeType(dr[prop.Name], prop.PropertyType), null);
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                postgreConnection.Connection.Close();
            } 
        }
    }
}
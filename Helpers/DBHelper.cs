using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Threading.Tasks;
using Npgsql;

namespace NutritionApi.Helpers
{
    public class DBHelper : IDBHelper
    {
        private readonly PostgreSQLConnection _postgreConnection;
        public DBHelper()
        {
            _postgreConnection = new PostgreSQLConnection();
        }

        public async Task<List<T>> Get<T>(String query, List<NpgsqlParameter> parameters)
        {
            try 
            {
                NpgsqlCommand cmd = _postgreConnection.Connection.CreateCommand();
                cmd.CommandType =  CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters.ToArray());
                await _postgreConnection.Connection.OpenAsync();
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
                _postgreConnection.Connection.Close();
            } 
        }

        public async Task<T> ExecuteScalar<T>(String query, List<NpgsqlParameter> parameters)
        {
            try 
            {
                NpgsqlCommand cmd = _postgreConnection.Connection.CreateCommand();
                cmd.CommandType =  CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters.ToArray());
                await _postgreConnection.Connection.OpenAsync();
                return (T) await cmd.ExecuteScalarAsync();
            }
            catch (NullReferenceException)
            {
                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default(T);
            }
            finally
            {
                _postgreConnection.Connection.Close();
            } 
        }
    }
}
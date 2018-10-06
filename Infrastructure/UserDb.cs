using NutritionApi.Helpers;
using NutritionApi.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using System.Threading.Tasks;

namespace NutritionApi.Infrastructure
{
    public class UserDb : IUser
    {
        private readonly IDBHelper _DBHelper;

        public UserDb(IDBHelper DBHelper)
        {
            _DBHelper = DBHelper;
        }

        public async Task<Int32> GetUserId(String mail, String password)
        {
           String query = @"SELECT us_id as Id FROM nutrition.user 
                            WHERE us_mail = @mail AND us_password = @password LIMIT 1";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(new NpgsqlParameter 
                { ParameterName = "mail", DbType = DbType.String, Value = mail });
            parameters.Add( new NpgsqlParameter
                { ParameterName = "password", DbType = DbType.String, Value = password });
            return await _DBHelper.ExecuteScalar<Int32>(query, parameters).ConfigureAwait(false);
        } 

        public async Task<Int32> CreateUser(String mail, String password)
        {
            String query = @"SELECT nutrition.""createUser""(@mail, @password)";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(new NpgsqlParameter 
                { ParameterName = "mail", DbType = DbType.String, Value = mail });
            parameters.Add( new NpgsqlParameter
                { ParameterName = "password", DbType = DbType.String, Value = password });
            return await _DBHelper.ExecuteScalar<Int32>(query, parameters).ConfigureAwait(false);
        }
    }
}
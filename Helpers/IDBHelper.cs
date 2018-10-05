using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;

namespace NutritionApi.Helpers
{
    public interface IDBHelper
    {
         Task<List<T>> Get<T>(String query, List<NpgsqlParameter> parameters);
         Task<T> ExecuteScalar<T>(String query, List<NpgsqlParameter> parameters);
    }
}
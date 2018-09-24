using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using NutritionApi.Domain.Entities;
using NutritionApi.Infrastructure.DAO;

namespace NutritionApi.Infrastructure
{
    public class MealDB
    {
        private readonly PostgreDB _db;

        public MealDB() {
            _db = new PostgreDB();
        }

        public async Task<List<AlimentEntity>> GetAliments(int mealId)
        {
           String query = @"SELECT al_id as Id FROM nutrition.meal_aliment 
                            WHERE meal_id = @mealId";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(new NpgsqlParameter 
                { ParameterName = "mealId", DbType = DbType.Int32, Value = mealId });
            return await _db.ExecuteQueryAsync<AlimentEntity>(query, parameters, CommandType.Text);
        }
    }
}
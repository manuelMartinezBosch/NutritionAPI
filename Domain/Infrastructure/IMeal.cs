using System.Collections.Generic;
using System.Threading.Tasks;
using NutritionApi.Domain.Entities;

namespace NutritionApi.Domain.Infrastructure
{
    public interface IMeal
    {
         Task<List<AlimentEntity>> GetAliments(int mealId);
    }
}
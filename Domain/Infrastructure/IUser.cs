using System;
using System.Threading.Tasks;

namespace NutritionApi.Domain.Infrastructure
{
    public interface IUser
    {
         Task<Int32> GetUserId(String mail, String password);
    }
}
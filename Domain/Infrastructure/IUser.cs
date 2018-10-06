using System;
using System.Threading.Tasks;

namespace NutritionApi.Domain.Infrastructure
{
    public interface IUser
    {
         Task<Int32> GetUserId(String mail, String password);
         Task<Int32> CreateUser(String mail, String password);
    }
}
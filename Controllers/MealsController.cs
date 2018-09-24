using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionApi.Domain.Entities;
using NutritionApi.Infrastructure;

namespace NutritionApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly MealDB _meal;

        public MealsController() 
        {
            _meal = new MealDB();
        }
        /// <summary>
        /// Get Meal Aliments
        /// </summary>
        /// <param name="mealId"></param>
        /// <returns></returns>
        [HttpGet("{mealId}", Name = "GetAliments")]
        public async Task<ActionResult<List<AlimentEntity>>> GetAliments(int mealId)
        {
            return await _meal.GetAliments(mealId);
        }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}

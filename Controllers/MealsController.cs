using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NutritionApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        /// <summary>
        /// Get Aliments
        /// </summary>
        /// <param name="mealId"></param>
        /// <returns></returns>
        [HttpGet("{mealId}", Name = "GetAliments")]
        public async Task<ActionResult<string>> GetAliments(int mealId)
        {
            return "value";
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

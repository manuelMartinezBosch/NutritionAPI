using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NutritionApi.Domain.Entities;
using NutritionApi.Domain.Infrastructure;
using NutritionApi.Helpers;
using NutritionApi.Infrastructure;

namespace NutritionApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMeal _meal;
        private readonly AppSettings _appSettings;
        public MealsController(IOptions<AppSettings> appsettings, IMeal meal) 
        {
            _appSettings = appsettings.Value;
            _meal = meal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mealId"></param>
        /// <returns></returns>
        [HttpGet("{mealId}", Name = "GetAliments")]
        public async Task<IActionResult> GetAliments(int mealId)
        {
            var headerToken = Request.Headers["Authorization"];
            string tokenString = headerToken.ToString().Substring(7);
            var jwt = new JwtSecurityTokenHandler().ReadToken(tokenString) as JwtSecurityToken;
            List<Claim> claims = jwt.Claims.ToList();
            Int64 id = jwt.Claims.Where(c => c.Type.Equals(ClaimTypes.Sid))
                   .Select(c => Convert.ToInt64(c.Value)).SingleOrDefault();
            //return Ok(await _meal.GetAliments(mealId));
            return Ok(new {Id = id});
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

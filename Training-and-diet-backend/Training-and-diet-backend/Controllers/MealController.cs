using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Services.Interfaces;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _service;

        public MealController(IMealService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeals()
        {
            var meals = await _service.GetMeals();

            if (meals.Count == 0)
                return NotFound("There is no diets in database");

            return Ok(meals);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.Services;

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

            return Ok(meals);
        }

        [HttpGet("{mealId}")]
        public async Task<IActionResult> GetMealById(int mealId)
        {
            var meal = await _service.GetMealById(mealId);

            return Ok(meal);
        }
        // do zmiany - przeniesc do userController
        [HttpGet("{dieticianId}/meals")]
        public async Task<IActionResult> GetMealsByDieticianId(int dieticianId)
        {
            var exercises = await _service.GetMealsByDieticianId(dieticianId);

            return Ok(exercises);
        }
        [HttpPost]
        public async Task<IActionResult> PostMeal(MealDto meal)
        {
            var result = await _service.CreateMeal(meal);

            return Ok(result);
        }
    }
}
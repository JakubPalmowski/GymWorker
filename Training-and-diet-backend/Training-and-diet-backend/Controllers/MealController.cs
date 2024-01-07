using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Queries.Meal;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MealController(IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeals()
        {
            var query = new GetMealsQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{mealId}")]
        public async Task<IActionResult> GetMealById(int mealId)
        {
            var query = new GetMealQuery(mealId);

            var result = await _mediator.Send(query);
            return Ok(result);
        }
      
        [HttpGet("{dieticianId}/meals")]
        public async Task<IActionResult> GetMealsByDieticianId(int dieticianId)
        {
            var query = new GetMealsByDieticianIdQuery(dieticianId);
            var mealsDto = await _mediator.Send(query);

            return Ok(mealsDto);
        }
        [HttpPost]
        public async Task<IActionResult> PostMeal(CreateMealCommand meal)
        {
            var result = await _mediator.Send(meal);
            var locationUri = $"api/meal/{result.IdMeal}";

            return Created(locationUri, result);
           


        }

        [HttpDelete("{mealId}")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            await _mediator.Send(new DeleteMealCommand(mealId));
            return NoContent();
        }
        [HttpPut("{mealId}")]
        public async Task<IActionResult> UpdateMeal (int mealId, UpdateMealCommand meal)       
        {
            await _mediator.Send(new UpdateMealInternalCommand(mealId, meal));
            return Ok();
        }
    }
}
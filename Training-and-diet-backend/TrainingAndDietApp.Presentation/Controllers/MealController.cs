using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.Meal.CreateMeal;
using TrainingAndDietApp.Application.CQRS.Commands.Meal.DeleteMeal;
using TrainingAndDietApp.Application.CQRS.Commands.Meal.UpdateMeal;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.UpdateTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Queries.Meal.GetAll;
using TrainingAndDietApp.Application.CQRS.Queries.Meal.GetByDieticianId;
using TrainingAndDietApp.Application.CQRS.Queries.Meal.GetById;
using TrainingAndDietApp.Domain.Entities;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "4,5")]
    public class MealController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MealController(IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMeals()
        {
            var query = new GetMealsQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{mealId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMealById(int mealId)
        {
            var query = new GetMealQuery(mealId);

            var result = await _mediator.Send(query);
            return Ok(result);
        }
      
        [HttpGet("dietician")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMealsByDieticianId()
        {
            var user = this.User.GetId()!.Value;
            var query = new GetMealsByDieticianIdQuery(user);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostMeal(CreateMealCommand meal)
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new CreateInternalMealCommand(user,meal));

            return Ok();
        }

        [HttpDelete("{mealId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            await _mediator.Send(new DeleteMealCommand(mealId));
            return NoContent();
        }
        [HttpPut("{mealId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMeal (int mealId, UpdateMealCommand meal)       
        {
            await _mediator.Send(new UpdateMealInternalCommand(mealId, meal));
            return Ok();
        }
    }
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Create;
using TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Delete;
using TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Update;
using TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetDietMeals;
using TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetMealDietForMentor;
using TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetMealDietForPupil;

namespace TrainingAndDietApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealDietController : ControllerBase
    {
       private readonly IMediator _mediator;

        public MealDietController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "4,5")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateMealDiet([FromBody] CreateMealDietCommand command)
        {
            var user = User.GetId()!.Value;
            var query = new CreateMealDietInternalCommand(user, command);
            var result = await _mediator.Send(query);

            return Ok(result);
    }
        [Authorize(Roles = "4,5")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMealDiet([FromBody] UpdateMealDietCommand command, int id)
        {
            var user = User.GetId()!.Value;
            var query = new UpdateMealDietInternalCommand(id,user, command);
            await _mediator.Send(query);

            return Ok();
    }
        [Authorize(Roles = "2,4,5")]
        [HttpGet("Meals/{idDiet}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDietMeals(int idDiet)
        {
            var user = User.GetId()!.Value;
            var query = new GetDietMealsQuery(idDiet, user);
            var result = await _mediator.Send(query);

            return Ok(result);
    }
        [Authorize(Roles = "4,5")]
        [HttpGet("Mentor/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMealDietForMentor(int id)
        {
            var user = User.GetId()!.Value;
            var query = new GetMealDietForMentorQuery(id, user);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "2")]
        [HttpGet("Pupil/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMealDietForPupil(int id)
        {
            var user = User.GetId()!.Value;
            var query = new GetMealDietForPupilQuery(id, user);
            var result = await _mediator.Send(query);

            return Ok(result);
    }

        [Authorize(Roles = "4,5")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMealDiet(int id)
        {
            var user = User.GetId()!.Value;
            var query = new DeleteMealDietCommand(id, user);
            await _mediator.Send(query);

            return Ok();
    }
    }
}

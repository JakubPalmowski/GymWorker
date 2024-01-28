using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.Di.Create;
using TrainingAndDietApp.Application.CQRS.Commands.Di.Update;
using TrainingAndDietApp.Application.CQRS.Queries.Diet.GetAll;
using TrainingAndDietApp.Application.CQRS.Queries.Diet.GetDieticianDiets;
using TrainingAndDietApp.Application.CQRS.Queries.Diet.GetPupilDiets;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {

        private readonly IMediator _mediator;
        

        public DietController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiets()
        {
            var query = new GetDietsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "4,5")]
        [HttpGet("Dietician")]
        public async Task<IActionResult> GetDieticianDiets()
        {
            var user = User.GetId()!.Value;
            var query = new GetDieticianDietsQuery(user);
            var result = await _mediator.Send(query);

            return Ok(result);
    }

        [Authorize(Roles = "2")]
        [HttpGet("Pupil")]
        public async Task<IActionResult> GetPupilDiets()
        {
            var user = User.GetId()!.Value;
            var query = new GetPupilDietsQuery(user);
            var result = await _mediator.Send(query);

            return Ok(result);
    }
        [Authorize(Roles = "4,5")]
        [HttpPost]
        public async Task<IActionResult> CreateDiet([FromBody] CreateDietCommand command)
        {
            var user = User.GetId()!.Value;
            var query = new CreateDietInternalCommand(user, command);
            var result = await _mediator.Send(query);

            return Ok(result);
    }
        [HttpPut("{idDiet}")]
        public async Task<IActionResult> UpdateDiet([FromBody] CreateDietCommand command, int idDiet)
        {
            //var user = User.GetId()!.Value;
            var query = new UpdateDietInternalCommand(idDiet, 2, command);
            await _mediator.Send(query);

            return NoContent();
}
    }
}

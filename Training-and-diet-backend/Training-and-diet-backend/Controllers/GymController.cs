using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAll;
using TrainingAndDietApp.Application.CQRS.Queries.Gym.GetMentors;
using TrainingAndDietApp.Application.Commands.Gym;
using TrainingAndDietApp.Application.Queries.Gym;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GymController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveGyms()
        {
            var request = new GetActiveGymsQuery();
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpGet("Mentor/{id}")]
        public async Task<IActionResult> GetMentorActiveGyms(int id)
        {
            var response = await _mediator.Send(new GetMentorActiveGymsQuery(id));

            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> CreateGym(CreateGymCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("User/{idUser}")]
        public async Task<IActionResult> GetAllGymsAddedByUser(int idUser)
        {
            var response = await _mediator.Send(new GetAllGymsAddedByUserQuery(idUser));

            return Ok(response);
        }
    }
}

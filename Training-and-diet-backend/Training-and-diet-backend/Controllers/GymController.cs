using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAll;
using TrainingAndDietApp.Application.CQRS.Queries.Gym.GetMentors;

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
        public async Task<IActionResult> GetAllGyms()
        {
            var request = new GetGymsQuery();
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpGet("Mentor/{id}")]
        public async Task<IActionResult> GetMentorGyms(int id)
        {
            var response = await _mediator.Send(new GetMentorGymsQuery(id));

            return Ok(response);

        }

    }
}

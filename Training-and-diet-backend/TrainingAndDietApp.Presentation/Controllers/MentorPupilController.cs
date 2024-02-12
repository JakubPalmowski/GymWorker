using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Queries.User.Mentor.GetAll;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "3,4,5")]
    public class MentorPupilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MentorPupilController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("MentorPupils")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMentorPupils()
        {
            var userId = this.User.GetId()!.Value;
            var query = new GetMentorPupilsQuery(userId);
            var result = await _mediator.Send(query);

            return Ok(result);

        }
    }
}

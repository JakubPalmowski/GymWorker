using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.Opinion.CreateOpinion;
using TrainingAndDietApp.Application.CQRS.Commands.Opinion.DeleteOpinion;
using TrainingAndDietApp.Application.CQRS.Commands.Opinion.UpdateOpinion;
using TrainingAndDietApp.Application.CQRS.Queries.Opinion.GetOpinionById;



namespace Training_and_diet_backend.Controllers
{
    [Authorize(Roles = "2")]
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OpinionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateOpinion([FromBody] CreateOpinionCommand command)
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new CreateOpinionInternalCommand(user, command));
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateOpinion([FromBody] CreateOpinionCommand command)
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new UpdateOpinionInternalCommand(user, command));
            return Ok();
        }

        [HttpGet("{idMentor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMyOpinionForMentor(int idMentor)
        {
            var user = this.User.GetId()!.Value;
            var opinion = await _mediator.Send(new GetOpinionByIdQuery(user, idMentor));
            return Ok(opinion);
        }
        [HttpDelete("Mentor/{idMentor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOpinion(int idMentor)
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new DeleteOpinionCommand(user, idMentor));
            return Ok();
    }

    }

}

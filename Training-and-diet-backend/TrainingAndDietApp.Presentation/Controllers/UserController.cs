using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.User.Dietician.UpdateDietician;
using TrainingAndDietApp.Application.CQRS.Commands.User.DieticianTrainer.UpdateDieticianTrainer;
using TrainingAndDietApp.Application.CQRS.Commands.User.Pupil.SendInvitation;
using TrainingAndDietApp.Application.CQRS.Commands.User.Pupil.UpdatePupil;
using TrainingAndDietApp.Application.CQRS.Commands.User.Trainer.UpdateTrainer;
using TrainingAndDietApp.Application.CQRS.Commands.User.User.DeleteInvitation;
using TrainingAndDietApp.Application.CQRS.Queries.User.Dietician.GetById;
using TrainingAndDietApp.Application.CQRS.Queries.User.DieticianTrainer.GetById;
using TrainingAndDietApp.Application.CQRS.Queries.User.Mentor.GetInvitations;
using TrainingAndDietApp.Application.CQRS.Queries.User.Pupil.GetById;
using TrainingAndDietApp.Application.CQRS.Queries.User.Trainer.GetById;
using TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll;
using TrainingAndDietApp.Application.CQRS.Queries.User.User.GetUserImage;
using UserQuery = TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll.UserQuery;


namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
      

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{RoleName}")]
        public async Task<IActionResult> GetUsers([FromRoute] string RoleName, [FromQuery] UserQuery userQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var query = new GetUsersQuery(RoleName, userQuery);
            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpGet("{RoleName}/{id}")]
        public async Task<IActionResult> GetUsersWithOpinionsById([FromRoute] string roleName, [FromRoute] int id)
        {
            int? userId = User.Identity.IsAuthenticated ? this.User.GetId()!.Value : null;
            var query = new GetMentorWithOpinionsQuery(roleName, id, userId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("Pupil/{id}")]
        public async Task<IActionResult> GetPupilById( [FromRoute] int id){
            var query = new GetPupilQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "2")]
        [HttpGet("Pupil/PersonalInfo")]
        public async Task<IActionResult> GetPupilPersonalInfoById(){
            var user = this.User.GetId()!.Value;
            var query = new GetPupilPersonalInfoQuery(user);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "2")]
        [HttpPut("Pupil")]
        public async Task<IActionResult> UpdatePupil([FromBody] UpdatePupilCommand pupil)       
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new UpdatePupilInternalCommand(user, pupil));
            return Ok();
        }

        [Authorize(Roles = "3")]
        [HttpGet("Trainer/PersonalInfo")]
        public async Task<IActionResult> GetTrainerPersonalInfoById( ){
            var user = this.User.GetId()!.Value;
            var query = new GetTrainerPersonalInfoQuery(user);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [Authorize(Roles = "3")]
        [HttpPut("Trainer/{id}")]
        public async Task<IActionResult> UpdateTrainer([FromBody] UpdateTrainerCommand trainer)       
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new UpdateTrainerInternalCommand(user, trainer));
            return Ok();
        }

        [Authorize(Roles = "4")]
        [HttpPut("Dietician")]
        public async Task<IActionResult> UpdateDietician([FromBody] UpdateDieticianCommand dietician)       
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new UpdateDieticianInternalCommand(user, dietician));
            return Ok();
        }

        [Authorize(Roles = "4")]
        [HttpGet("Dietician/PersonalInfo")]
        public async Task<IActionResult> GetDieticianPersonalInfoById(){
            var user = this.User.GetId()!.Value;
            var query = new GetDieticianPersonalInfoQuery(user);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "5")]
        [HttpPut("DieticianTrainer")]
        public async Task<IActionResult> UpdateDieticianTrainer([FromBody] UpdateDieticianTrainerCommand dieticianTrainer)       
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new UpdateDieticianTrainerInternalCommand(user, dieticianTrainer));
            return Ok();
        }

        [Authorize(Roles = "5")]
        [HttpGet("DieticianTrainer/PersonalInfo")]
        public async Task<IActionResult> GetDieticianTrainerPersonalInfoById(){
            var user = this.User.GetId()!.Value;
            var query = new GetDieticianTrainerPersonalInfoQuery(user);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "2")]
        [HttpPost("Pupil/Invitation/{idMentor}")]
        public async Task<IActionResult> SendInvitation([FromRoute] int idMentor)
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new SendInvitationCommand(user, idMentor));
            return Ok();
        }

        [Authorize(Roles = "2,3,4,5")]
        [HttpDelete("Invitation/{idUser}")]
        public async Task<IActionResult> DeleteInvitation([FromRoute] int idUser)
        {
            var user = this.User.GetId()!.Value;
            await _mediator.Send(new DeleteInvitationCommand(user, idUser));
            return Ok();
        }

        [Authorize]
        [HttpGet("Image")]
        public async Task<IActionResult> GetUserImage()
        {
            var user = this.User.GetId()!.Value;
            var query = new GetUserImageQuery(user);
            var result = await _mediator.Send(query);
            return Ok(result);

       
    }
        [Authorize(Roles = "3,4,5")]
        [HttpGet("Invitations")]
        public async Task<IActionResult> GetMentorInvitations()
        {
            var user = this.User.GetId()!.Value;
            var query = new GetInvitationsQuery(user);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
}
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.Commands.User.Dietician;
using TrainingAndDietApp.Application.Commands.User.DieticianTrainer;
using TrainingAndDietApp.Application.Commands.User.Pupil;
using TrainingAndDietApp.Application.Commands.User.Trainer;
using TrainingAndDietApp.Application.Queries.User;
using UserQuery = TrainingAndDietApp.Application.Queries.User.UserQuery;


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


        // POBIERA lISTĘ UZYTKOWNIKOW Z PODANEJ ROLI
        [HttpGet("{RoleName}")]
        public async Task<IActionResult> GetUsers([FromRoute] string RoleName, [FromQuery] UserQuery userQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var query = new GetUsersQuery(RoleName, userQuery);
            var result = await _mediator.Send(query);

            return Ok(result);

        }

        //Pobiera trenera/Dietetyka/TreneroDietetyka wraz z jego opiniami po Id
        [HttpGet("{RoleName}/{id}")]
        public async Task<IActionResult> GetUsersWithOpinionsById([FromRoute] string roleName, [FromRoute] int id)
        {
            var query = new GetMentorWithOpinionsQuery(roleName, id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("Pupil/{id}")]
        public async Task<IActionResult> GetPupilById( [FromRoute] int id){
            var query = new GetPupilQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet("Pupil/PersonalInfo/{id}")]
        public async Task<IActionResult> GetPupilPersonalInfoById( [FromRoute] int id){
            var query = new GetPupilPersonalInfoQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("Pupil/{id}")]
        public async Task<IActionResult> UpdatePupil(int id, [FromBody] UpdatePupilCommand pupil)       
        {
            await _mediator.Send(new UpdatePupilInternalCommand(id, pupil));
            return Ok();
        }

        [HttpGet("Trainer/PersonalInfo/{id}")]
        public async Task<IActionResult> GetTrainerPersonalInfoById( [FromRoute] int id){
            var query = new GetTrainerPersonalInfoQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("Trainer/{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, [FromBody] UpdateTrainerCommand trainer)       
        {
            await _mediator.Send(new UpdateTrainerInternalCommand(id, trainer));
            return Ok();
        }

        [HttpPut("Dietician/{id}")]
        public async Task<IActionResult> UpdateDietician(int id, [FromBody] UpdateDieticianCommand dietician)       
        {
            await _mediator.Send(new UpdateDieticianInternalCommand(id, dietician));
            return Ok();
        }

        [HttpGet("Dietician/PersonalInfo/{id}")]
        public async Task<IActionResult> GetDieticianPersonalInfoById( [FromRoute] int id){
            var query = new GetDieticianPersonalInfoQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("DieticianTrainer/{id}")]
        public async Task<IActionResult> UpdateDieticianTrainer(int id, [FromBody] UpdateDieticianTrainerCommand dieticianTrainer)       
        {
            await _mediator.Send(new UpdateDieticianTrainerInternalCommand(id, dieticianTrainer));
            return Ok();
        }

        [HttpGet("DieticianTrainer/PersonalInfo/{id}")]
        public async Task<IActionResult> GetDieticianTrainerPersonalInfoById( [FromRoute] int id){
            var query = new GetDieticianTrainerPersonalInfoQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

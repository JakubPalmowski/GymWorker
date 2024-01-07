using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        //Pobiera trenera wraz z jego opiniami po Id
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

    }
}

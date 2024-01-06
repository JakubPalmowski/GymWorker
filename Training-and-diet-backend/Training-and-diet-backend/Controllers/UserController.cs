using MediatR;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Queries.TrainingPlan;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.User;
using TrainingAndDietApp.DAL.EntityModels;
using UserQuery = TrainingAndDietApp.Application.Queries.User.UserQuery;


namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceDeprecated _serviceDeprecated;
        private readonly IMediator _mediator;
      

        public UserController(IUserServiceDeprecated userServiceDeprecated, IMediator mediator)
        {
            _serviceDeprecated = userServiceDeprecated;
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
        public async Task<ActionResult<MentorWithOpinionDto>> GetUsersWithOpinionsById([FromRoute] string roleName, [FromRoute] int id)
        {
            var trainer = await _serviceDeprecated.GetMentorWithOpinionsById(roleName, id);
            return Ok(trainer);
        }

        [HttpGet("Pupil/{id}")]
        public async Task<ActionResult<PupilDto>> GetPupilById( [FromRoute] int id){
            var pupil = await _serviceDeprecated.GetPupilById(id);
            return Ok(pupil);
        }

    }
}

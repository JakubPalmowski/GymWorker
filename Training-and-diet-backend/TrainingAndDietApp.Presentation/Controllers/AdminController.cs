using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyGym;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllGymsAdmin;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetGymByIdAdmin;
using TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainerId;


namespace Training_and_diet_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllGyms/{status}")]
        public async Task<IActionResult> GetAllGymsAdmin(string status)
        {
            var request = new GetAllGymsAdminQuery(status);
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpDelete("Gym/{idGym}")]
        public async Task<IActionResult> DeleteGym(int idGym)
        {
            var request = new DeleteGymCommand(idGym);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("Gym/{idGym}")]
        public async Task<IActionResult> GetGymById(int idGym)
        {
            var request = new GetGymByIdAdminQuery(idGym);
            var response = await _mediator.Send(request);
            return Ok(response);
    }

        [HttpPut("Gym/{idGym}")]
        public async Task<IActionResult> EditGym(int idGym, UpdateGymCommand command)
        {   
            await _mediator.Send(new UpdateGymInternalCommand(idGym, command));
            return Ok();
        }

        [HttpPut("Gym/Verify/{idGym}")]
        public async Task<IActionResult> VerifyGym(int idGym, UpdateGymCommand command)
        {
            await _mediator.Send(new VerifyGymInternalCommand(idGym, command));
            return Ok();
        }

        [HttpGet("Exercises")]
        public async Task<IActionResult> GetAdminAllExercises()
        {
            var response = await _mediator.Send(new GetAllExercisesAdminQuery());
            return Ok(response);

        }
    }
}
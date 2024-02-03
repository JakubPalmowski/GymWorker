using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.AssignPupil;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.CreateTrainingPlan;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.UpdateTrainingPlan;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById.Pupil;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById.Trainer;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByPupilId;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByTrainerId;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainingPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "3,5")]
        [HttpGet("trainer/{planId}")]
        public async Task<IActionResult> GetTrainerTrainingPlanById(int planId)
        {
            var loggedUser = this.User.GetId()!.Value;
            var query = new GetTrainerTrainingPlanQuery(planId, loggedUser);

            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [Authorize(Roles = "2")]
        [HttpGet("pupil/{planId}")]
        public async Task<IActionResult> GetPupilTrainingPlanById(int planId)
        {
            var loggedUser = this.User.GetId()!.Value;
            var query = new GetPupilTrainingPlanQuery(planId, loggedUser);

            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [Authorize(Roles = "3,5")]
        [HttpGet("trainerPlans")]
        public async Task<IActionResult> GetTrainerTrainingPlans()
        {
            var user = this.User.GetId()!.Value;
            var query = new GetTrainerTrainingPlansQuery(user);
            var result = await _mediator.Send(query);

            return Ok(result);

        }
        [Authorize(Roles = "2")]
        [HttpGet("pupilPlans")]
        public async Task<IActionResult> GetPupilTrainingPlans()
        {
            var user = this.User.GetId()!.Value;
            var query = new GetPupilTrainingPlansQuery(user);
            var result = await _mediator.Send(query);

            return Ok(result);

        }
        [Authorize(Roles = "3,5")]
        [HttpPost]
        public async Task<IActionResult> PostTrainingPlan(CreateTrainingPlanCommand command)
        {
            var userId = this.User.GetId()!.Value;
            var result = await _mediator.Send(new CreateInternalTrainingPlanCommand(userId, command));
            var locationUri = $"api/command/{result.IdTrainingPlan}";
            
            return Created(locationUri, command);
        }
        [Authorize(Roles = "3,5")]
        [HttpPut("{idTrainingPlan}")]
        public async Task<IActionResult> UpdateTrainingPlan(int idTrainingPlan, UpdateTrainingPlanCommand trainingPlan)
        {
            var command = new UpdateTrainingPlanInternalCommand(idTrainingPlan, trainingPlan);
            await _mediator.Send(command);
            return NoContent();
        }
        [Authorize(Roles = "3,5")]
        [HttpPut("assignPupilToTrainingPlan/{idTrainingPlan}")]
        public async Task<IActionResult> AssignPupilToTrainingPlan(int idTrainingPlan, AssignPupilToTrainingPlanCommand trainingPlan)
        {
            var user = this.User.GetId()!.Value;
            var command = new AssignPupilToTrainingPlanInternalCommand(idTrainingPlan, user, trainingPlan);
            await _mediator.Send(command);
            return NoContent();
        }

        

    }
}

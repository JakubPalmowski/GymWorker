using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.AssignPupil;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.CreateTrainingPlan;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.UpdateTrainingPlan;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById;
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
        [HttpGet("{planId}")]
        public async Task<IActionResult> GetTrainingPlanById(int planId)
        {
            var query = new GetTrainingPlanQuery(planId);

            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [HttpGet("{idTrainer}/trainingPlans")]
        public async Task<IActionResult> GetTrainerTrainingPlans(int idTrainer)
        {
            var query = new GetTrainerTrainingPlansQuery(idTrainer);
            var result = await _mediator.Send(query);

            return Ok(result);

        }
        [Authorize(Roles = "3")]
        [HttpPost]
        public async Task<IActionResult> PostTrainingPlan(CreateTrainingPlanCommand command)
        {
            var userId = this.User.GetId()!.Value;
            var result = await _mediator.Send(new CreateInternalTrainingPlanCommand(userId, command));
            var locationUri = $"api/command/{result.IdTrainingPlan}";
            
            return Created(locationUri, command);
        }

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

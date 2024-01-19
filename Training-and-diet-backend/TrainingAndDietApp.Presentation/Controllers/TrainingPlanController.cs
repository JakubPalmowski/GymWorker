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
    [Authorize(Roles = "3,5")]
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
        [HttpGet]
        public async Task<IActionResult> GetTrainerTrainingPlans()
        {
            var user = this.User.GetId()!.Value;
            var query = new GetTrainerTrainingPlansQuery(user);
            var result = await _mediator.Send(query);

            return Ok(result);

        }
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

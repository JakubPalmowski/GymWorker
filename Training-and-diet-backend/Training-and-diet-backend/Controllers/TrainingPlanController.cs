using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Queries.TrainingPlan;

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

        

    }
}

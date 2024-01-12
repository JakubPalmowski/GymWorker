using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost] 
        public async Task<IActionResult> PostTrainingPlan(CreateTrainingPlanCommand trainingPlan)
        {
            var result = await _mediator.Send(trainingPlan);
            var locationUri = $"api/trainingPlan/{result.IdTrainingPlan}";

            return Created(locationUri, trainingPlan);
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

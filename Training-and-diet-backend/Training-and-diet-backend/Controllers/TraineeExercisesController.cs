using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.CreateTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.DeleteTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.UpdateTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainingPlanId;
using TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeExercisesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TraineeExercisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraineeExercises(int id)
        {
            var result = await _mediator.Send(new GetTraineeExerciseQuery(id));
            return Ok(result);
        }
        [HttpGet("trainingPlanInternal/{idTrainingPlan}")]
        public async Task<IActionResult> GetTraineeExercisesFromTrainingPlan(int idTrainingPlan)
        {
            var request = new GetExercisesFromTrainingPlanQuery(idTrainingPlan);
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> PostTraineeExercise(CreateTraineeExerciseCommand exercise)
        {
            var result = await _mediator.Send(exercise);
            var locationUri = $"api/exercise/{result.IdTraineeExercise}";

            return Created(locationUri, result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraineeExercise(int id, UpdateTraineeExerciseCommand exercise)
        {
            await _mediator.Send(new UpdateTraineeExerciseInternalCommand(id, exercise));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraineeExercise(int id)
        {
            await _mediator.Send(new DeleteTraineeExerciseCommand(id));
            return NoContent();
        }
    }
}

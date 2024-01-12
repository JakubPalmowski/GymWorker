using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Queries.TraineeExercise;

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
    }
}

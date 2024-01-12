using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Queries.Exercise;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ExerciseController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{exerciseId}")]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            var request = new GetExerciseQuery(exerciseId);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var request = new GetExercisesQuery();
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpGet("{trainerId}/exercises")]
        public async Task<IActionResult> GetTrainerExercises(int trainerId)
        {
            var request = new GetTrainerExercisesQuery(trainerId);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostExercise(CreateExerciseCommand exercise)
        {
            var result = await _mediator.Send(exercise);
            var locationUri = $"api/exercise/{result.IdExercise}";

            return Created(locationUri, result);
        }

        [HttpPut("{exerciseId}")]
        public async Task<IActionResult> PutExercise(UpdateExerciseCommand exercise, int exerciseId)
        {
            await _mediator.Send(new UpdateExerciseInternalCommand(exerciseId, exercise));
            return Ok();
        }

        

        [HttpDelete("{exerciseId}")]
        public async Task<ActionResult<int>> DeleteExercise(int exerciseId)
        {
            await _mediator.Send(new DeleteExerciseCommand(exerciseId));
            return NoContent();
        }

    }
}

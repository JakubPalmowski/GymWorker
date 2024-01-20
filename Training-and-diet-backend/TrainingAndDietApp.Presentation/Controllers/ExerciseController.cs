using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.DeleteExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.UpdateExercise;
using TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetAll;
using TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetById;
using TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainerId;

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
        public async Task<IActionResult> GetSystemExercises()
        {
            var request = new GetSystemExercisesQuery();
            var response = await _mediator.Send(request);

            return Ok(response);

        }
        [Authorize(Roles = "3,5")]
        [HttpGet("trainer/exercises")]
        public async Task<IActionResult> GetTrainerExercises()
        {
            var userId = this.User.GetId()!.Value;
            var request = new GetTrainerExercisesQuery(userId);
            var response = await _mediator.Send(request);

            return Ok(response);
        }
        [Authorize(Roles = "3,5")]
        [HttpPost]
        public async Task<IActionResult> PostExercise(CreateExerciseCommand exercise)
        {
            var userId = this.User.GetId()!.Value; 
            var result = await _mediator.Send(new CreateInternalExerciseCommand(userId, exercise));
            var locationUri = $"api/exercise/{result.IdExercise}";

            return Created(locationUri, result);
        }
        [Authorize(Roles = "3,5")]
        [HttpPut("{exerciseId}")]
        public async Task<IActionResult> PutExercise(UpdateExerciseCommand exercise, int exerciseId)
        {
            await _mediator.Send(new UpdateExerciseInternalCommand(exerciseId, exercise));
            return Ok();
        }


        [Authorize(Roles = "3,5")]
        [HttpDelete("{exerciseId}")]
        public async Task<IActionResult> DeleteExercise(int exerciseId)
        {
            await _mediator.Send(new DeleteExerciseCommand(exerciseId));
            return NoContent();
        }

    }
}

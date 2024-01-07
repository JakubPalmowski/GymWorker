﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.Commands.TraineeExercises;

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
      
        [HttpPost]
        public async Task<IActionResult> PostTraineeExercise(CreateTraineeExerciseCommand exercise)
        {
            var result = await _mediator.Send(exercise);
            var locationUri = $"api/exercise/{result.IdTraineeExercise}";

            return Created(locationUri, result);

        }
    }
}

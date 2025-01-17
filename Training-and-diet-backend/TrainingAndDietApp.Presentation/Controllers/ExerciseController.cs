﻿using AutoMapper;
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
    [Authorize(Roles = "3,5")]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet("{exerciseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            var request = new GetExerciseQuery(exerciseId);
            var response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSystemExercises()
        {
            var request = new GetSystemExercisesQuery();
            var response = await _mediator.Send(request);

            return Ok(response);

        }
        [HttpGet("trainer/exercises")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTrainerExercises()
        {
            var userId = this.User.GetId()!.Value;
            var request = new GetTrainerExercisesQuery(userId);
            var response = await _mediator.Send(request);

            return Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PostExercise(CreateExerciseCommand exercise)
        {
            var userId = this.User.GetId()!.Value; 
            var result = await _mediator.Send(new CreateInternalExerciseCommand(userId, exercise));
            var locationUri = $"api/exercise/{result.IdExercise}";

            return Created(locationUri, result);
        }
  
        [HttpPut("{exerciseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutExercise(UpdateExerciseCommand exercise, int exerciseId)
        {
            await _mediator.Send(new UpdateExerciseInternalCommand(exerciseId, exercise));
            return Ok();
        }


        [HttpDelete("{exerciseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteExercise(int exerciseId)
        {
            await _mediator.Send(new DeleteExerciseCommand(exerciseId));
            return Ok();
        }

    }
}

﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.CreateTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.DeleteTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.UpdateTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainingPlanId;
using TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById;
using TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById.Pupil;
using TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById.Trainer;

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
        //dodac autoryzacje
        [Authorize(Roles = "3,5")]
        [HttpGet("trainer/{id}")]
        public async Task<IActionResult> GetTrainerTraineeExercises(int id)
        {
            var loggedUser = this.User.GetId()!.Value;
            var result = await _mediator.Send(new GetTrainerTraineeExerciseQuery(id, loggedUser));
            return Ok(result);
        }
        //dodac autoryzacje
        [Authorize(Roles = "2")]
        [HttpGet("pupil/{id}")]
        public async Task<IActionResult> GetPupilTraineeExercises(int id)
        {
            var loggedUser = this.User.GetId()!.Value;
            var result = await _mediator.Send(new GetPupilTraineeExerciseQuery(id, loggedUser));
            return Ok(result);
        }
        //dodac autoryzacje
        [Authorize(Roles = "3,5")]
        [HttpGet("trainingPlanInternal/{idTrainingPlan}")]
        public async Task<IActionResult> GetTraineeExercisesFromTrainingPlan(int idTrainingPlan)
        {
            var request = new GetExercisesFromTrainingPlanQuery(idTrainingPlan);
            var response = await _mediator.Send(request);

            return Ok(response);

        }
        [Authorize(Roles = "3,5")]
        [HttpPost]
        public async Task<IActionResult> PostTraineeExercise(CreateTraineeExerciseCommand exercise)
        {
            var result = await _mediator.Send(exercise);
            var locationUri = $"api/exercise/{result.IdTraineeExercise}";

            return Created(locationUri, result);

        }
        [Authorize(Roles = "3,5")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraineeExercise(int id, UpdateTraineeExerciseCommand exercise)
        {
            await _mediator.Send(new UpdateTraineeExerciseInternalCommand(id, exercise));
            return NoContent();
        }
        [Authorize(Roles = "3,5")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraineeExercise(int id)
        {
            await _mediator.Send(new DeleteTraineeExerciseCommand(id));
            return NoContent();
        }
    }
}

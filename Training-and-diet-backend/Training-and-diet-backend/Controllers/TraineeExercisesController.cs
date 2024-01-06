using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.TraineeExercise;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.DAL.Models;

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

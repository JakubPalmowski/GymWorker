using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Entities;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _service;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ExerciseController(IExerciseService service, IMapper mapper, IMediator mediator)
        {
            _service = service;
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

        [HttpGet("trainingPlans/{idTrainingPlan}/exercises")]
        public async Task<IActionResult> GetExercisesFromTrainingPlan(int idTrainingPlan)
        {
            var request = new GetExercisesFromTrainingPlanQuery(idTrainingPlan);
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpDelete("{exerciseId}")]
        public async Task<ActionResult<int>> DeleteExercise(int exerciseId)
        {
            await _mediator.Send(new DeleteExerciseCommand(exerciseId));
            return NoContent();
        }

    }
}

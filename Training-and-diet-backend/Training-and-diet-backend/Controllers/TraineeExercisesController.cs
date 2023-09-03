using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeExercisesController : ControllerBase
    {
        private readonly ITraineeExercisesService _service;
        public TraineeExercisesController(ITraineeExercisesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task <IActionResult> AddTraineeExercises([FromBody] PostTraineeExerciseDTO traineeExercise)
        {
            if (traineeExercise == null)
                return BadRequest("Post should have a body");

            var data = new Trainee_exercise
            {
                Series_number = traineeExercise.Series_Number,
                Repetitions_number = traineeExercise.Repetitions_number,
                Comments = traineeExercise.Comments,
                Date = traineeExercise.Date, 
                Id_Exercise = traineeExercise.Id_Exercise,
                Id_Training_plan = traineeExercise.Id_Training_plan

            };

            await _service.AddTraineeExercises(data);
            return Ok(data.Id_Exercise);
        }
    }
}

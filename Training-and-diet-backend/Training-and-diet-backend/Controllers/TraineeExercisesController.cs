using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.TraineeExercise;
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
        // do zmiany
        [HttpPost]
        public async Task <IActionResult> AddTraineeExercises([FromBody] TraineeExerciseDto traineeExercise)
        {
           

            var data = new TraineeExercise
            {
                SeriesNumber = traineeExercise.Series_Number,
                RepetitionsNumber = traineeExercise.Repetitions_number,
                Comments = traineeExercise.Comments,
                Date = traineeExercise.Date, 
                IdExercise = traineeExercise.Id_Exercise,
                IdTrainingPlan = traineeExercise.Id_Training_plan

            };

            await _service.AddTraineeExercises(data);
            return Ok(data.IdTraineeExercise);
        }
    }
}

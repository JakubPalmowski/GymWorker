using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : ControllerBase
    {
        private readonly ITrainingPlanService _service;
        public TrainingPlanController(ITrainingPlanService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingPlan([FromBody] PostTrainingPlanDTO trainingPlan)
        {
            if (trainingPlan == null)
            {
                return BadRequest();
            }


            var plan = new Training_plan
            {
                Name = trainingPlan.Name,
                Type = trainingPlan.Type,
                Start_date = trainingPlan.Start_date,
                End_date = trainingPlan.End_date,
                Id_Trainer = trainingPlan.Id_Trainer,

            };

            await _service.AddTrainingPlan(plan);
            return Ok(plan.Id_Training_plan);
        }
        [HttpGet("{id_training_plan}/exercises")]
        public async Task<IActionResult> GetExercisesFromTrainingPlan(int id_training_plan)
        {
            var exercises = await _service.GetExercisesFromTrainingPlan(id_training_plan);
            if (exercises.Count == 0)
            {
                return NotFound("There are no exercises assigned to this training plan");
            }
            return Ok(exercises);

        }
    }
}

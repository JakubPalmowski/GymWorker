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
        public IActionResult CreateTrainingPlan([FromBody] PostTrainingPlanDTO TrainingPlan)
        {
            if (TrainingPlan == null)
            {
                return BadRequest();
            }

            var plan = new Training_plan
            {
                Name = TrainingPlan.Name,
                Type = TrainingPlan.Type,
                Start_date = TrainingPlan.Start_date,
                End_date = TrainingPlan.End_date,
                Plan_duration = TrainingPlan.Plan_duration,
                Id_Trainer = TrainingPlan.Id_Trainer,

            };

            _service.AddTrainingPlan(plan);
            return Ok(TrainingPlan);
        }
    }
}

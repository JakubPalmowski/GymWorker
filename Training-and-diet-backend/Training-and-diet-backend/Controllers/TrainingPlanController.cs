using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.BLL.Services;

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
        public async Task<IActionResult> CreateTrainingPlan([FromBody] TrainingPlanCreateDto trainingPlan)
        {

            var id = await _service.AddTrainingPlan(trainingPlan);
            return Created($"/api/trainingplan/{id}", new { id });

        }


        [HttpGet("{PlanId}")]
        public async Task<IActionResult> GetTrainingPlanById(int PlanId)
        {
            var plan = await _service.GetTrainingPlanById(PlanId);

            return Ok(plan);
        }
    }
}

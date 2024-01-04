using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.TraineeExercise;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.TrainingPlan;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : ControllerBase
    {
        private readonly ITrainingPlanService _service;
        private readonly IMapper _mapper;
        public TrainingPlanController(ITrainingPlanService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTrainingPlan([FromBody] CreateTrainingPlanDto trainingPlanDto)
        {
            var trainingPlanEntity = _mapper.Map<TrainingPlanEntity>(trainingPlanDto);
            var id = await _service.AddTrainingPlan(trainingPlanEntity);

            return Ok(id);

        }


        [HttpGet("{planId}")]
        public async Task<ActionResult<TrainingPlanDetailsDto>> GetTrainingPlanById(int planId)
        {
            var plan = await _service.GetTrainingPlanById(planId);
            var planDto = _mapper.Map<TrainingPlanDetailsDto>(plan);

            return Ok(planDto);
        }
    }
}

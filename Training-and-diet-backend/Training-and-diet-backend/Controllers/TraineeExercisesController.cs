using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.TraineeExercise;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.DAL.Models;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeExercisesController : ControllerBase
    {
        private readonly ITraineeExercisesService _service;
        private readonly IMapper _mapper;
        public TraineeExercisesController(ITraineeExercisesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
      
        [HttpPost]
        public async Task<ActionResult<int>> AddTraineeExercises([FromBody] TraineeExerciseDto traineeExerciseDto)
        {
            var traineeExerciseEntity = _mapper.Map<TraineeExerciseEntity>(traineeExerciseDto);
            var data = await _service.AddTraineeExercises(traineeExerciseEntity);

            return Ok(data);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.Exercise;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _service;
        private readonly IMapper _mapper;
        public ExerciseController(IExerciseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{exerciseId}")]
        public async Task<ActionResult<ExerciseNameDto>> GetExerciseById(int exerciseId)
        {
            var exerciseDomainModels = await _service.GetExerciseById(exerciseId);
            var exerciseDTO = _mapper.Map<ExerciseNameDto>(exerciseDomainModels);


            return Ok(exerciseDTO);
        }

        [HttpGet]
        public async Task<ActionResult<ExerciseNameDto>> GetAllExercises()
        {
            var exercisesDomainModels = await _service.GetAllExercises();
            var exerciseDto = _mapper.Map<List<ExerciseNameDto>>(exercisesDomainModels);

            return Ok(exerciseDto);

        }

        [HttpPost]
        public async Task<ActionResult<int>> PostExercise(ExerciseDto exercise)
        {
            var exerciseEntity = _mapper.Map<ExerciseEntity>(exercise);
            var result = await _service.CreateExercise(exerciseEntity);

            return Ok(result);
        }

        [HttpPut("{exerciseId}")]
        public async Task<ActionResult<int>> PutExercise([FromBody] ExerciseDto exerciseDto, int exerciseId)
        {
            var exerciseEntity = _mapper.Map<ExerciseEntity>(exerciseDto);
            var result = await _service.UpdateExercise(exerciseEntity, exerciseId);

            return Ok(result);
        }

        [HttpGet("trainingPlans/{idTrainingPlan}/exercises")]
        public async Task<ActionResult<ExerciseNameDto>> GetExercisesFromTrainingPlan(int idTrainingPlan)
        {
            var exercisesEntity= await _service.GetExercisesFromTrainingPlan(idTrainingPlan);
            var exerciseDto = _mapper.Map<List<ExerciseNameDto>>(exercisesEntity);

            return Ok(exerciseDto);

        }

        [HttpDelete("{exerciseId}")]
        public async Task<ActionResult<int>> DeleteExercise(int exerciseId)
        {
            var result = await _service.DeleteExercise(exerciseId);

            return Ok(result);
        }

    }
}

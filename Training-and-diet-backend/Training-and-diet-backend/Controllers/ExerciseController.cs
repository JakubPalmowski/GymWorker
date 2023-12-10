using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Services;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _service;
        public ExerciseController(IExerciseService service)
        {
            _service=service;
        }

        [HttpGet("{ExerciseId}")]
        public async Task<IActionResult> GetExerciseById(int ExerciseId) {

            var exist = await _service.GetExerciseById(ExerciseId).FirstOrDefaultAsync();

            
            return Ok(exist);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _service.GetAllExercises();

            return Ok(exercises);

        }

        
    }
}

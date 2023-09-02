using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController (IUserService userService)
        {
            _service = userService;
        }

        [HttpGet("{TrainerId}")]

        public async Task<IActionResult> GetTrainerExercises(int TrainerId)
        {
            var exercises = await _service.GetTrainerExercises(TrainerId);

            if (exercises.Count == 0)
                return NotFound("There are no exercises assigned to this trainer");

            return Ok(exercises);
        }
        

    }
}

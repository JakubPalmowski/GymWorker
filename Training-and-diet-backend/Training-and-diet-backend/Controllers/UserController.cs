using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;

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

        [HttpGet("{TrainerId}/exercises")]

        public async Task<IActionResult> GetTrainerExercises(int TrainerId)
        {
            var exercises = await _service.GetTrainerExercises(TrainerId);

            

            return Ok(exercises);
        }

        [HttpGet("{id_trainer}/trainingPlans")]
        public async Task<ActionResult<IEnumerable<GetTrainingPlanGeneralInfoDTO>>> GetTrainerTrainingPlans(int id_trainer)
        {
            var trainingPlans = await _service.GetTrainerTrainingPlans(id_trainer);
            if (trainingPlans.Count == 0)
            {
                return NotFound("There are no training plans for the trainer");
            }
            return Ok(trainingPlans);

        }


        [HttpGet("{id_trainer}/pupils")]
        public async Task<ActionResult<IEnumerable<User>>> GetPupilsByTrainerId(int id_trainer)
        {
            var trainerPupils = await _service.GetPupilsByTrainerId(id_trainer);
            if (trainerPupils.Count == 0)
            {
                return NotFound("The trainer has no pupils");
            }
            return Ok(trainerPupils);
        }


    }
}

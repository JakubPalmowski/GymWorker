using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.User;


namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
      

        public UserController(IUserService userService)
        {
            _service = userService;
        }



        // POBIERA WSZYSTKIE CWICZENIA TRENERA PO ID, WYSWIETLA WSZYSTKIE DANE CWICZENIA

        [HttpGet("{TrainerId}/exercises")]

        public async Task<IActionResult> GetTrainerExercises(int TrainerId)
        {
            var exercises = await _service.GetExercisesByTrainerId(TrainerId);



            return Ok(exercises);
        }

        [HttpGet("{id_trainer}/trainingPlans")]
        public async Task<ActionResult<IEnumerable<TrainingPlanNameDto>>> GetTrainerTrainingPlans(int id_trainer)
        {
            var trainingPlans = await _service.GetTrainerTrainingPlans(id_trainer);

            return Ok(trainingPlans);

        }


        [HttpGet("{id_trainer}/pupils")]
        public async Task<ActionResult<IEnumerable<User>>> GetPupilsByTrainerId(int id_trainer)
        {
            var trainerPupils = await _service.GetPupilsByTrainerId(id_trainer);

            return Ok(trainerPupils);
        }

        // POBIERA lISTĘ UZYTKOWNIKOW Z PODANEJ ROLI
        [HttpGet("{RoleName}")]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetUsers([FromRoute] string RoleName, [FromQuery] UserQuery query = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var trainers = await _service.GetMentors(RoleName, query);
            return Ok(trainers);
        }

        //Pobiera trenera wraz z jego opiniami po Id
        [HttpGet("{RoleName}/{id}")]
        public async Task<ActionResult<MentorWithOpinionDto>> GetUsersWithOpinionsById([FromRoute] string roleName, [FromRoute] int id)
        {
            var trainer = await _service.GetMentorWithOpinionsById(roleName, id);
            return Ok(trainer);
        }

        [HttpGet("Pupil/{id}")]
        public async Task<ActionResult<PupilDto>> GetPupilById( [FromRoute] int id){
            var pupil = await _service.GetPupilById(id);
            return Ok(pupil);
        }

    }
}

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



        // POBIERA WSZYSTKIE CWICZENIA TRENERA PO ID, WYSWIETLA WSZYSTKIE DANE CWICZENIA

        /*[HttpGet("{TrainerId}/exercises")]

        public async Task<IActionResult> GetTrainerExercises(int TrainerId)
        {
            var exercises = await _service.GetTrainerExercises(TrainerId);

            

            return Ok(exercises);
        }*/

        [HttpGet("{id_trainer}/trainingPlans")]
        public async Task<ActionResult<IEnumerable<GetTrainingPlanGeneralInfoDTO>>> GetTrainerTrainingPlans(int id_trainer)
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

        // POBIERA WSZYSTKIE CWICZENIA TRENERA PO ID, WYSWIETLA TYLKO NAME I ID CWICZENIA

        [HttpGet("{TrainerId}/exercises")]
        public async Task<IActionResult> GetExercisesByTrainerId(int TrainerId)
        {
            var exercises = await _service.GetExercisesByTrainerId(TrainerId);


            return Ok(exercises);
        }

        // POBIERA lISTĘ TRENENRÓW
        [HttpGet("trainers")]
        public async Task<ActionResult<IEnumerable<GetTrainersDTO>>> GetTrainers()
        {
            var trainers = await _service.GetTrainers();
            return Ok(trainers);
        }

        //Pobiera trenera wraz z jego opiniami po Id
        [HttpGet("trainers/{id}")]
        public async Task<ActionResult<GetTrainerWithOpinionsByIdDTO>> GetTrainerWithOpinionsByTrainerId(int id)
        {
            var trainer = await _service.GetTrainerWithOpinionsById(id);
            return Ok(trainer);
        }



    }
}

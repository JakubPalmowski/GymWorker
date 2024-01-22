using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteCertificate;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyCertificate;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyUser;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllGymsAdmin;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllUsersWithAcceptedCertificates;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllUsersWithPendingCertificates;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetCertificateInfoForVerification;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetGymByIdAdmin;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserCertificatesById;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserInfoForVerification;
using TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainerId;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;



namespace Training_and_diet_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllGyms/{status}")]
        public async Task<IActionResult> GetAllGymsAdmin(string status)
        {
            var request = new GetAllGymsAdminQuery(status);
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpDelete("Gym/{idGym}")]
        public async Task<IActionResult> DeleteGym(int idGym)
        {
            var request = new DeleteGymCommand(idGym);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("Gym/{idGym}")]
        public async Task<IActionResult> GetGymById(int idGym)
        {
            var request = new GetGymByIdAdminQuery(idGym);
            var response = await _mediator.Send(request);
            return Ok(response);
    }

        [HttpPut("Gym/{idGym}")]
        public async Task<IActionResult> EditGym(int idGym, UpdateGymCommand command)
        {   
            await _mediator.Send(new UpdateGymInternalCommand(idGym, command));
            return Ok();
        }

        [HttpPut("Gym/Verify/{idGym}")]
        public async Task<IActionResult> VerifyGym(int idGym, UpdateGymCommand command)
        {
            await _mediator.Send(new VerifyGymInternalCommand(idGym, command));
            return Ok();
        }

        [HttpGet("Exercises")]
        public async Task<IActionResult> GetAdminAllExercises()
        {
            var response = await _mediator.Send(new GetAllExercisesAdminQuery());
            return Ok(response);

        }

        [HttpPost("Exercises")]
        public async Task<IActionResult> CreateExercise(CreateExerciseCommand command)
        {
            var response = await _mediator.Send(new CreateExerciseAdminInternalCommand(command));
            return Ok(response);
        }

        [HttpGet("Users/PendingCertificates")]
        public async Task<IActionResult> GetAllUsersWithPendingCertificates()
        {
            var response = await _mediator.Send(new GetAllUsersWithPendingCertificatesQuery());
            return Ok(response);

        }

        [HttpGet("Users/AcceptedCertificates")]
        public async Task<IActionResult> GetAllUsersWithAcceptedCertificates()
        {
            var response = await _mediator.Send(new GetAllUsersWithAcceptedCertificatesQuery());
            return Ok(response);

        }

        [HttpGet("Users/{id}")]
        public async Task<IActionResult> GetUserInfoForVerification(int id)
        {
            var response = await _mediator.Send(new GetUserInfoForVerificationQuery(id));
            return Ok(response);

        }

        [HttpGet("Users/Certificates/{idUser}")]
        public async Task<IActionResult> GetUserCertificatesById(int idUser)
        {
            var request = new GetUserCertificatesByIdQuery(idUser);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("Certificates/{idCertificate}")]
        public async Task<IActionResult> GetCertificateInfoForVerification(int idCertificate)
        {
            var request = new GetCertificateInfoForVerificationQuery(idCertificate);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        //czy tutaj git? nie wysylam nic w body ale zmieniam wartosci obiektu w bazie danych
        [HttpPatch("Certificates/Verification/{idCertificate}")]
        public async Task<IActionResult> VerifyCertificate(int idCertificate)
        {
            var request = new VerifyCertificateCommand(idCertificate);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("Certificates/{idCertificate}")]
        public async Task<IActionResult> DeleteCertificate(int idCertificate)
        {
            var request = new DeleteCertificateCommand(idCertificate);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPatch("Users/Verification/{idUser}")]
        public async Task<IActionResult> VerifyUser(int idUser, VerifyUserCommand command)
        {
            await _mediator.Send(new VerifyUserInternalCommand(idUser, command));
            return Ok();
        }
    }
}
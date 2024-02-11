using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteCertificate;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyCertificate;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyGym;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyUser;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.UpdateExercise;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAdminExerciseById;
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
    [Authorize(Roles = "1")]

    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllGyms/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllGymsAdmin(string status)
        {
            var request = new GetAllGymsAdminQuery(status);
            var response = await _mediator.Send(request);

            return Ok(response);

        }

        [HttpDelete("Gym/{idGym}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGym(int idGym)
        {
            var request = new DeleteGymCommand(idGym);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("Gym/{idGym}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGymById(int idGym)
        {
            var request = new GetGymByIdAdminQuery(idGym);
            var response = await _mediator.Send(request);
            return Ok(response);
    }

        [HttpPut("Gym/{idGym}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGym(int idGym, UpdateGymCommand command)
        {   
            await _mediator.Send(new UpdateGymInternalCommand(idGym, command));
            return Ok();
        }

        [HttpPut("Gym/Verify/{idGym}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerifyGym(int idGym, UpdateGymCommand command)
        {
            await _mediator.Send(new VerifyGymInternalCommand(idGym, command));
            return Ok();
        }

        [HttpGet("Exercises")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAdminAllExercises()
        {
            var response = await _mediator.Send(new GetAllExercisesAdminQuery());
            return Ok(response);

        }

        [HttpPost("Exercises")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateExercise(CreateExerciseCommand command)
        {
            var response = await _mediator.Send(new CreateExerciseAdminInternalCommand(command));
            return Ok(response);
        }

        [HttpGet("Users/PendingCertificates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUsersWithPendingCertificates()
        {
            var response = await _mediator.Send(new GetAllUsersWithPendingCertificatesQuery());
            return Ok(response);

        }

        [HttpGet("Users/AcceptedCertificates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUsersWithAcceptedCertificates()
        {
            var response = await _mediator.Send(new GetAllUsersWithAcceptedCertificatesQuery());
            return Ok(response);

        }

        [HttpGet("Users/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserInfoForVerification(int id)
        {
            var response = await _mediator.Send(new GetUserInfoForVerificationQuery(id));
            return Ok(response);

        }

        [HttpGet("Users/Certificates/{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserCertificatesById(int idUser)
        {
            var request = new GetUserCertificatesByIdQuery(idUser);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("Certificates/{idCertificate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCertificateInfoForVerification(int idCertificate)
        {
            var request = new GetCertificateInfoForVerificationQuery(idCertificate);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("Certificates/Verification/{idCertificate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerifyCertificate(int idCertificate)
        {
            var request = new VerifyCertificateCommand(idCertificate);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("Certificates/{idCertificate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCertificate(int idCertificate)
        {
            var request = new DeleteCertificateCommand(idCertificate);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPatch("Users/Verification/{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerifyUser(int idUser, VerifyUserCommand command)
        {
            await _mediator.Send(new VerifyUserInternalCommand(idUser, command));
            return Ok();
        }
        [HttpGet("Exercises/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAdminExercisesById(int id)
        {
            var request = new GetAdminExerciseByIdQuery(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("Exercises/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAdminExercise(int id, UpdateExerciseCommand command)
        {
            await _mediator.Send(new UpdateAdminExerciseInternalCommand(id, command));
            return Ok();
        }

        [HttpDelete("Exercises/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdminExercise(int id)
        {
            await _mediator.Send(new DeleteAdminExerciseCommand(id));
            return Ok();
        }
    }
}
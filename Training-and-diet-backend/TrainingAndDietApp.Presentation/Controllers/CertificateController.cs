using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate;
using TrainingAndDietApp.Application.CQRS.Queries.Certificate.GetUserCertificates;

namespace Training_and_diet_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "3,4,5")]
    public class CertificateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificateController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromForm] CreateCertificateCommand certificateCommand)
        {
            var user = this.User.GetId()!.Value;
            if (certificateCommand.PdfFile == null)
                return BadRequest("File is null.");

            var response = await _mediator.Send(new CreateCertificateInternalCommand(user, certificateCommand));
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest("File upload failed.");
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserCertificates()
        {
            var user = this.User.GetId()!.Value;
            var response = await _mediator.Send(new GetUserCertificatesQuery(user));
                return Ok(response);

        }
    }
}

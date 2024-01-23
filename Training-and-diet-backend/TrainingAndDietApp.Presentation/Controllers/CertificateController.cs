using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate;
using TrainingAndDietApp.Application.CQRS.Queries.Certificate.GetUserCertificates;

namespace TrainingAndDietApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "3,4,5")]
        [HttpPost]
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
        [Authorize(Roles = "3,4,5")]
        public async Task<IActionResult> GetUserCertificates()
        {
            var user = this.User.GetId()!.Value;
            var response = await _mediator.Send(new GetUserCertificatesQuery(user));
                return Ok(response);

        }
    }
}

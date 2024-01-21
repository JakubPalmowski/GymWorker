using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate;

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

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, [FromForm] CreateCertificateCommand certificateCommand)
        {
            var response = await _mediator.Send(new CreateCertificateInternalCommand(file, 6, certificateCommand));
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest("File upload failed.");
    }
}
}

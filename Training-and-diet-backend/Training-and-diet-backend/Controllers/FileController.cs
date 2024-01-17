using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Commands.Files;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMediator _mediator;

        public FileController(IFileService fileService, IMediator mediator)
        {
            _fileService = fileService;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var files = await _fileService.ListAsync();
            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var response = await _mediator.Send(new UploadFileCommand( file,6));
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest("File upload failed.");
        }

        [HttpGet("{blobFileName}")]
        public async Task<IActionResult> Download(string blobFileName)
        {
            var response = await _fileService.DownloadAsync(blobFileName);
            if (response == null)
            {
                return NotFound();
            }

            return File(response.Content, response.ContentType, response.Name);
        }
    }
}

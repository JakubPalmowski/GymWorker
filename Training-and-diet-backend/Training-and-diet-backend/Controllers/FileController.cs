using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.CQRS.Commands.Files.Delete;
using TrainingAndDietApp.Application.CQRS.Commands.Files.Upload;
using TrainingAndDietApp.Application.CQRS.Queries.Files.Download;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var response = await _mediator.Send(new UploadFileCommand( file,6));
            if (response.IsSuccess)
                return Ok(response);
            
            return BadRequest("File upload failed.");
        }

        [HttpGet("{blobFileName}")]
        public async Task<IActionResult> Download(string blobFileName)
        {
           var query = new DownloadBlobQuery(blobFileName);

           var result = await _mediator.Send(query);

           return File(result.Content, result.ContentType, result.Name);
        }
        [HttpDelete("delete/{blobFileName}")]
        public async Task<IActionResult> Delete(string blobFileName)
        {
            var command = new DeleteFileCommand(blobFileName, 6);
            var result = await _mediator.Send(command);

            if (result)
                return Ok($"File {blobFileName} deleted successfully");
            
            return NotFound($"File {blobFileName} not found");
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Extensions;
using TrainingAndDietApp.Application.CQRS.Commands.Files.Delete;
using TrainingAndDietApp.Application.CQRS.Commands.Files.Upload;
using TrainingAndDietApp.Application.CQRS.Queries.Files.Download;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1,2,3,4,5")]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var user = this.User.GetId()!.Value;
            var response = await _mediator.Send(new UploadFileCommand( file,user));
            if (response.IsSuccess)
                return Ok(response);
            
            return BadRequest("File upload failed.");
        }
        [AllowAnonymous]
        [HttpGet("{blobFileName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Download(string blobFileName)
        {
           var query = new DownloadBlobQuery(blobFileName);

           var result = await _mediator.Send(query);

           return File(result.Content, result.ContentType, result.Name);
        }
        [HttpDelete("delete/{blobFileName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string blobFileName)
        {
            var user = this.User.GetId()!.Value;
            var command = new DeleteFileCommand(blobFileName, user);
            var result = await _mediator.Send(command);

            if (result)
                return Ok($"File {blobFileName} deleted successfully");
            
            return NotFound($"File {blobFileName} not found");
        }
    }
}

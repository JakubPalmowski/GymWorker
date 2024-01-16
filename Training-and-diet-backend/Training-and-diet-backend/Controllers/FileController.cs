using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAndDietApp.Application.Abstractions;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
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
            var response = await _fileService.UploadAsync(file);
            return Ok(response);
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Services.Interfaces;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IDietService _service;

        public DietController(IDietService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiets()
        {
            var diets = await _service.GetDiets();

            return Ok(diets);
        }
    }
}

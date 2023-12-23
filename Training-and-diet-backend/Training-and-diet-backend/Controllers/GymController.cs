using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Services;
using Training_and_diet_backend.Services.Interfaces;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGymService _service;

        public GymController(IGymService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGyms()
        {
            var gyms = await _service.GetGyms();

            return Ok(gyms);
        }

    }
}

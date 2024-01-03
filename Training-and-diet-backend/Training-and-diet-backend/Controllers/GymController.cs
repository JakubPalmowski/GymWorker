using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.Gym;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGymService _service;
        private readonly IMapper _mapper;

        public GymController(IGymService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GymDto>>> GetAllGyms()
        {
            var gyms = await _service.GetGyms();
            var dtos = _mapper.Map<List<GymDto>>(gyms);

            return Ok(dtos);
        }

    }
}

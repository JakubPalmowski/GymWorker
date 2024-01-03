using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.Common.DTOs.Diet;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IDietService _service;
        private readonly IMapper _mapper;
        

        public DietController(IDietService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DietDto>>> GetAllDiets()
        {
            var diets = await _service.GetDiets();
            var dtos = _mapper.Map<List<DietDto>>(diets);

            return Ok(dtos);
        }
    }
}

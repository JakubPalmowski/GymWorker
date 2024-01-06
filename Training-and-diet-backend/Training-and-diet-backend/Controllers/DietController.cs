using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.Application.Queries.Diet;
using TrainingAndDietApp.Common.DTOs.Diet;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {

        private readonly IMediator _mediator;
        

        public DietController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiets()
        {
            var query = new GetDietsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}

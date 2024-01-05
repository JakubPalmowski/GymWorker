using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.MealDto;
using TrainingAndDietApp.Application.Commands;
using TrainingAndDietApp.Application.Queries;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.BLL.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMealService _service;
        private readonly IMapper _mapper;

        public MealController(IMealService service, IMapper mapper, IMediator mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeals()
        {
            var query = new GetMealsQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{mealId}")]
        public async Task<IActionResult> GetMealById(int mealId)
        {
            var query = new GetMealQuery(mealId);

            var result = await _mediator.Send(query);
            return Ok(result);
        }
        // do zmiany - przeniesc do userController
        [HttpGet("{dieticianId}/meals")]
        public async Task<IActionResult> GetMealsByDieticianId(int dieticianId)
        {
            var query = new GetMealsByDieticianIdQuery(dieticianId);
            var mealsDto = await _mediator.Send(query);

            return Ok(mealsDto);
        }
        [HttpPost]
        public async Task<IActionResult> PostMeal(CreateMealCommand meal)
        {
            var result = await _mediator.Send(meal);
            var locationUri = $"api/meal/{result.IdMeal}";

            return Created(locationUri, result);
           


        }

        [HttpDelete("{mealId}")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            await _mediator.Send(new DeleteMealCommand(mealId));
            return NoContent();
        }
        [HttpPut("{mealId}")]
        public async Task<IActionResult> UpdateMeal (int mealId, UpdateMealCommand meal)       
        {
            await _mediator.Send(new UpdateMealInternalCommand(mealId, meal));
            return Ok();
        }
    }
}
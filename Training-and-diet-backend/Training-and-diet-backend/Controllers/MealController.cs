using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.DAL.Models;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _service;
        private readonly IMapper _mapper;

        public MealController(IMealService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MealDto>>> GetAllMeals()
        {
            var mealDomainModels = await _service.GetMeals();
            var mealDTOs = _mapper.Map<List<MealDto>>(mealDomainModels);

            return Ok(mealDTOs);
        }

        [HttpGet("{mealId}")]
        public async Task<ActionResult<MealDto>> GetMealById(int mealId)
        {
            var meal = await _service.GetMealById(mealId);
            var mealDto = _mapper.Map<MealDto>(meal);

            return Ok(mealDto);
        }
        // do zmiany - przeniesc do userController
        [HttpGet("{dieticianId}/meals")]
        public async Task<ActionResult<List<MealDto>>> GetMealsByDieticianId(int dieticianId)
        {
            var meals = await _service.GetMealsByDieticianId(dieticianId);
            var mealsDto = _mapper.Map<List<MealDto>>(meals);
            

            return Ok(mealsDto);
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostMeal(MealDto meal)
        {
            var mealEntity = _mapper.Map<MealEntity>(meal);
            var result = await _service.CreateMeal(mealEntity);

            return Ok(result);
        }
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.Exceptions;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;

namespace Training_and_diet_backend.Services
{
    public interface IMealService
    {
        Task<List<Meal>> GetMeals();
        Task<MealDto?> GetMealById(int mealId);
        Task<List<MealDto>> GetMealsByDieticianId(int dieticianId);
        Task<int> CreateMeal(MealDto mealDto);
    }
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public MealService(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<List<Meal>> GetMeals()
        {
            var meals = await _mealRepository.GetMealsAsync();

            if (meals.Count == 0)
                throw new NotFoundException("No meals found");

            return meals;
        }
        public async Task<MealDto?> GetMealById(int mealId)
        {
            var meal = await _mealRepository.GetMealByIdAsync(mealId);

            if (meal == null)
                throw new NotFoundException("Meal not found");

            return _mapper.Map<MealDto>(meal);
        }

        public async Task<List<MealDto>> GetMealsByDieticianId(int dieticianId)
        {
            var meal = await _mealRepository.GetMealsByDieticianIdAsync(dieticianId);

            if (!meal.Any())
                throw new NotFoundException("Meals not found");

            return _mapper.Map<List<MealDto>>(meal);
        }

        public async Task<int> CreateMeal(MealDto mealDto)
        {
            var meal = _mapper.Map<Meal>(mealDto);

            return await _mealRepository.AddMealAsync(meal);
        }
    }
}

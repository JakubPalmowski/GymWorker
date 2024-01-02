using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.Exceptions;

namespace Training_and_diet_backend.Services
{
    public interface IMealService
    {
        Task<List<MealDto>> GetMeals();
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

        public async Task<List<MealDto>> GetMeals()
        {
            var mealEntities = await _mealRepository.GetMealsAsync();
            if (mealEntities.Count == 0)
                throw new NotFoundException("No meals found");

            // Map entities to domain models
            var mealDomainModels = _mapper.Map<List<MealDto>>(mealEntities);

            return mealDomainModels;




        }
        public async Task<MealDto?> GetMealById(int mealId)
        {
            var meal = await _mealRepository.GetMealByIdAsync(mealId);

            if (meal == null)
                throw new NotFoundException("MealEntity not found");

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
            var meal = _mapper.Map<MealEntity>(mealDto);

            return await _mealRepository.AddMealAsync(meal);
        }
    }
}

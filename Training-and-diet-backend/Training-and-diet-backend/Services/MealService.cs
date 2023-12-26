using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Exceptions;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;

namespace Training_and_diet_backend.Services
{
    public interface IMealService
    {
        Task<List<Meal>> GetMeals();
    }
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;

        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<List<Meal>> GetMeals()
        {
            var meals = await _mealRepository.GetMealsAsync();

            if (meals.Count == 0)
                throw new NotFoundException("No meals found");

            return meals;
        }
    }
}

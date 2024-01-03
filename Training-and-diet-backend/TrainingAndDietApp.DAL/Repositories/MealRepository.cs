using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.Models;

namespace Training_and_diet_backend.Repositories
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetMealsAsync();
        Task<Meal?> GetMealByIdAsync(int mealId);
        Task<List<Meal>> GetMealsByDieticianIdAsync(int dieticianId);
        Task<int> AddMealAsync(Meal meal);
        
    }
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;

        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meal>> GetMealsAsync()
        {
            return await _context.Meals.ToListAsync();
        }
        public async Task<Meal?> GetMealByIdAsync(int mealId)
        {
            return await _context.Meals
                .Where(m => m.IdMeal == mealId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Meal>> GetMealsByDieticianIdAsync(int dieticianId)
        {
            return await _context.Meals
                .Where(m => m.IdDietician == dieticianId)
                .ToListAsync();
        }
        
        public async Task<int> AddMealAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
            return meal.IdMeal;
        }
       
        
    }
}
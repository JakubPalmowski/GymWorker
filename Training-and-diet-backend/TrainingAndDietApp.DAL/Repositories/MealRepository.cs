using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;

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
                .Where(m => m.Id_Meal == mealId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Meal>> GetMealsByDieticianIdAsync(int dieticianId)
        {
            return await _context.Meals
                .Where(m => m.Id_Dietetician == dieticianId)
                .ToListAsync();
        }
        //refactor, wrzucic exception do service
        public async Task<int> AddMealAsync(Meal meal)
        {
            if (!await DieticianExists(meal.Id_Dietetician))
                throw new NotFoundException($"Dietician with ID {meal.Id_Dietetician} not found");

            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
            return meal.Id_Meal;
        }

        private async Task<bool> DieticianExists(int? dieticianId)
        {
            return await _context.Users.AnyAsync(d => d.Id_User == dieticianId);
        }
    }
}
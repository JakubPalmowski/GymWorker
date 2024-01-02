using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;

namespace Training_and_diet_backend.Repositories
{
    public interface IMealRepository
    {
        Task<List<MealEntity>> GetMealsAsync();
        Task<MealEntity?> GetMealByIdAsync(int mealId);
        Task<List<MealEntity>> GetMealsByDieticianIdAsync(int dieticianId);
        Task<int> AddMealAsync(MealEntity mealEntity);
        
    }
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;

        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MealEntity>> GetMealsAsync()
        {
            return await _context.Meals.ToListAsync();
        }
        public async Task<MealEntity?> GetMealByIdAsync(int mealId)
        {
            return await _context.Meals
                .Where(m => m.IdMeal == mealId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<MealEntity>> GetMealsByDieticianIdAsync(int dieticianId)
        {
            return await _context.Meals
                .Where(m => m.IdDietician == dieticianId)
                .ToListAsync();
        }
        //refactor, wrzucic exception do service
        public async Task<int> AddMealAsync(MealEntity mealEntity)
        {
            if (!await DieticianExists(mealEntity.IdDietician))
                throw new NotFoundException($"Dietician with ID {mealEntity.IdDietician} not found");

            await _context.Meals.AddAsync(mealEntity);
            await _context.SaveChangesAsync();
            return mealEntity.IdMeal;
        }

        private async Task<bool> DieticianExists(int? dieticianId)
        {
            return await _context.Users.AnyAsync(d => d.IdUser == dieticianId);
        }
    }
}
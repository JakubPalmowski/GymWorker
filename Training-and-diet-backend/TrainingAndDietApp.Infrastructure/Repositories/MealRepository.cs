using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Infrastructure.Context;

namespace Training_and_diet_backend.Repositories
{

    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;

        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meal>> GetMealsAsync(CancellationToken cancellationToken)
        {
            return await _context.Meals.ToListAsync(cancellationToken: cancellationToken);
        }
        public async Task<Meal?> GetMealByIdAsync(int mealId, CancellationToken cancellationToken)
        {
            var meal =  await _context.Meals
                .Where(m => m.IdMeal == mealId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return meal;
        }

        public async Task<List<Meal>> GetMealsByDieticianIdAsync(int dieticianId, CancellationToken cancellationToken)
        {
            return await _context.Meals
                .Where(m => m.IdDietician == dieticianId)
                .ToListAsync(cancellationToken: cancellationToken);
        }
        
        public async Task<int> AddMealAsync(Meal meal,CancellationToken cancellationToken)
        {
            await _context.Meals.AddAsync(meal, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return meal.IdMeal;
        }
        public async Task<int> DeleteMealAsync(int mealId, CancellationToken cancellationToken)
        {
            var meal = await _context.Meals
                .Where(meal => meal.IdMeal== mealId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);


            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync(cancellationToken);
            return meal.IdMeal;
        }
        public async Task<int> UpdateMealAsync(Meal meal, CancellationToken cancellationToken)
        {
            
            _context.Meals.Update(meal);
            await _context.SaveChangesAsync(cancellationToken);
            return meal.IdMeal;
        }


    }
}
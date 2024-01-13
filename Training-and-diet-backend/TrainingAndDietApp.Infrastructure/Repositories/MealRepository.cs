using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
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

        
        public async Task<List<Meal>> GetMealsByDieticianIdAsync(int dieticianId, CancellationToken cancellationToken)
        {
            return await _context.Meals
                .Where(m => m.IdDietician == dieticianId)
                .ToListAsync(cancellationToken: cancellationToken);
        }
        
      

    }
}
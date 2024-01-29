using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    public class MealDietRepository : IMealDietRepository
    {
        private readonly ApplicationDbContext _context;

        public MealDietRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MealDiet?> GetMealDietByIdAsync(int idMealDiet, CancellationToken cancellationToken)
        => await _context.Meal_Diets.Where(x => x.IdMealDiet == idMealDiet).Include(x=>x.Meal).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<MealDiet>> GetMealsByDietIdAsync(int dietId, CancellationToken cancellationToken)
        => await _context.Meal_Diets.Where(x => x.IdDiet == dietId).Include(x => x.Meal).ToListAsync(cancellationToken);
    }
}

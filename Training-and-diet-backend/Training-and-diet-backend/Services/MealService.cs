using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services.Interfaces;

namespace Training_and_diet_backend.Services
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext _context;

        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meal>> GetMeals()
        {
            var query =  await _context.Meals.ToListAsync();

            if(query.Count == 0)
                throw new Exception("No meals found");

            return query;

            
        }
    }
}

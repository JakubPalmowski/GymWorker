using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Exceptions;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services.Interfaces
{
    public interface IDietService
    {
        Task<List<Diet>> GetDiets();
    }
    public class DietService : IDietService
    {
        private readonly ApplicationDbContext _context;

        public DietService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Diet>> GetDiets()
        {
            var diets =  await _context.Diets.ToListAsync();
            if (diets.Count == 0)
                throw new NotFoundException("There is no diets in database");

            return diets;
        }
    }
}

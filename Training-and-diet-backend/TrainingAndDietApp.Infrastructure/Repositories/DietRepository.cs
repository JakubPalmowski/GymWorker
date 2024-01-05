using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.Domain.Abstractions;

namespace Training_and_diet_backend.Repositories
{
   


    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext _context;

        public DietRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // do zmiany na DietDTO
        public async Task<List<Diet>> GetDietsAsync()
        {
            return await _context.Diets.ToListAsync();
        }
    }
}

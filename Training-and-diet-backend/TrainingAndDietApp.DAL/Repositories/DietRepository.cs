using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;
namespace Training_and_diet_backend.Repositories
{
    public interface IDietRepository
    { 
        Task<List<Diet>> GetDietsAsync();
    }


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

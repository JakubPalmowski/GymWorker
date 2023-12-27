using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Repositories
{
    public interface IGymRepository
    {
        Task<List<Gym>> GetGymsAsync();
    }

    public class GymRepository : IGymRepository
    {
        private readonly ApplicationDbContext _context;

        public GymRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Gym>> GetGymsAsync()
        {
            return await _context.Gyms.Include(g => g.Address).ToListAsync();
        }

    }

}

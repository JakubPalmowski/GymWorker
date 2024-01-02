using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;

namespace TrainingAndDietApp.DAL.Repositories
{
    public interface IGymRepository
    {
        Task<List<GymEntity>> GetGymsAsync();
    }

    public class GymRepository : IGymRepository
    {
        private readonly ApplicationDbContext _context;

        public GymRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GymEntity>> GetGymsAsync()
        {
            return await _context.Gyms.Include(g => g.AddressEntity).ToListAsync();
        }

    }

}

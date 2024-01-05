using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.DAL.Repositories
{

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

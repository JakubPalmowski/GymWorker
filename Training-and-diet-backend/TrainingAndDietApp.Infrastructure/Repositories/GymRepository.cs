using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{

    public class GymRepository : IGymRepository
    {
        private readonly ApplicationDbContext _context;

        public GymRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gym>> GetActiveGymsWithAddressAsync(CancellationToken cancellationToken)
        =>  await _context.Gyms.Where(g=>g.Status == Domain.Enums.Status.Active).Include(g => g.Address).ToListAsync(cancellationToken: cancellationToken);
       

        public async Task<List<Gym>> GetMentorActiveGymsAsync(int idUser, CancellationToken cancellationToken)
        {
            return await _context.Trainer_Gyms
                .Where(tg => tg.IdTrainer == idUser && tg.Gym.Status == Domain.Enums.Status.Active)
                .Include(tg => tg.Gym.Address)
                .Select(tg => tg.Gym)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }

}

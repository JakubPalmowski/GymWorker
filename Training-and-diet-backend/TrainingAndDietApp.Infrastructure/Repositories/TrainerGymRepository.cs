using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    public class TrainerGymRepository : ITrainerGymRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainerGymRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TrainerGym trainerGym, CancellationToken cancellationToken)
        {
            await _context.Trainer_Gyms.AddAsync(trainerGym);
        }

        public async Task DeleteAsync(TrainerGym trainerGym, CancellationToken cancellationToken)
        {
            _context.Trainer_Gyms.Remove(trainerGym);
        }

        public async Task<TrainerGym?> GetByIdAsync(int idUser, int idGym, CancellationToken cancellationToken)
        => await _context.Trainer_Gyms.Where(tg => tg.IdTrainer == idUser && tg.IdGym == idGym).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}

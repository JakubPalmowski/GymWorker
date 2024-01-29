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
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext _context;

        public DietRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Diet>> GetDieticianDietsAsync(int dieticianId, CancellationToken cancellationToken)
        => await _context.Diets.Where(diet => diet.IdDietician == dieticianId).ToListAsync(cancellationToken);

        public async Task<Diet?> GetMentorDietAsync(int dietId, CancellationToken cancellationToken)
        => await _context.Diets.Where(diet => diet.IdDiet == dietId).Include(d=>d.Pupil).FirstOrDefaultAsync(cancellationToken);

        public async Task<Diet?> GetPupilDietAsync(int dietId, CancellationToken cancellationToken)
        => await _context.Diets.Where(diet => diet.IdDiet == dietId).Include(d=>d.Dietician).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<Diet>> GetPupilDietsAsync(int pupilId, CancellationToken cancellationToken)
        => await _context.Diets.Where(diet => diet.IdPupil == pupilId).Include(d=>d.Dietician).ToListAsync(cancellationToken);
    }
}

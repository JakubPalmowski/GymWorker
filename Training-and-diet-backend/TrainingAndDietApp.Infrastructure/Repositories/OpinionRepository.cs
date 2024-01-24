
using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace Training_and_diet_backend.Repositories
{

    public class OpinionRepository : IOpinionRepository
    {
        private readonly ApplicationDbContext _context;

        public OpinionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteOpinionAsync(Opinion opinion, CancellationToken cancellation)
        {
            _context.Opinions.Remove(opinion);
        }

        public async Task<Opinion?> GetPupilMentorOpinionAsync(int idPupil, int IdMentor, CancellationToken cancellation)
        => await _context.Opinions.Where(o => o.IdPupil == idPupil && o.IdMentor == IdMentor).FirstOrDefaultAsync(cancellation);

      
    }
}
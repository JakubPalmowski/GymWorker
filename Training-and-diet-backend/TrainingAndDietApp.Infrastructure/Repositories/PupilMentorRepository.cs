using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;


namespace TrainingAndDietApp.Infrastructure.Repositories
{
    public class PupilMentorRepository : IPupilMentorRepository
    {
        private readonly ApplicationDbContext _context;

        public PupilMentorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeletePupilMentorAsync(PupilMentor pupilMentor, CancellationToken cancellation)
        {
            _context.Pupil_mentors.Remove(pupilMentor);
        }

        public async Task<List<PupilMentor>> GetInvitationsAsync(int idMentor, CancellationToken cancellation)
        => await _context.Pupil_mentors.Where(pm => pm.IdMentor == idMentor && pm.IsAccepted == false).Include(r=>r.Pupil).ToListAsync(cancellation);

        public async Task<PupilMentor?> IsPupilCooperatingWithMentor(int idPupil, int idMentor, CancellationToken cancellationToken)
        => await _context.Pupil_mentors.FirstOrDefaultAsync(pm => pm.IdPupil == idPupil && pm.IdMentor == idMentor, cancellationToken: cancellationToken);
    }
}

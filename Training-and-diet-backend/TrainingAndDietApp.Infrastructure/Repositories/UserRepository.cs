using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.DAL.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public async Task<List<User>> GetPupilsByTrainerIdAsync(int id_trainer)
        {
            return await _context.Users
                .Where(u => _context.Pupil_mentors
                    .Where(e => e.IdMentor == id_trainer)
                    .Select(e => e.IdPupil)
                    .Contains(u.IdUser))
                .ToListAsync();
        }

        

        public async Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.IdUser == id, cancellationToken: cancellationToken);

            
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AnyAsync(predicate);
        }


        public async Task<bool> UserIsDietician(int dieticianId, CancellationToken cancellationToken)
        {

            return await _context.Users.Where(u => u.IdUser == dieticianId)
                .Select(u => u.Role)
                .AnyAsync(r => r.Name == "Dietician" || r.Name == "Dietician-Trainer");
        }
    }
}

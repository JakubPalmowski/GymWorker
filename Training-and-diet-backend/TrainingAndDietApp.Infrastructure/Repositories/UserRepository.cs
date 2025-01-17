﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public async Task<List<User>> GetPupilsByTrainerIdAsync(int idTrainer, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => _context.Pupil_mentors
                    .Where(e => e.IdMentor == idTrainer && e.IsAccepted == true)
                    .Select(e => e.IdPupil)
                    .Contains(u.IdUser))
                .ToListAsync(cancellationToken);
        }


        public async Task<User?> GetUserWithGymsAndOpinionsAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => u.IdUser == id && u.IsAccepted == true)
                .Include(u=>u.Role)
                .Include(u => u.MentorOpinions)
                .ThenInclude(u => u.Pupil)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User?> GetByEmailWithRoleAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<User?> GetByIdWithRoleAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(u => u.IdUser == id, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AnyAsync(predicate);
        }

        public IQueryable<User> GetUsersWithDetails(string? roleName, string? searchPhrase, CancellationToken cancellationToken)
        {
            return  _context.Users
                .Where(u => u.IsAccepted == true)
                .Include(u => u.MentorOpinions)
                .Include(u => u.Role)
                .Include(u => u.TrainerGyms)
                .ThenInclude(tg => tg.Gym)
                .ThenInclude(g => g.Address)
                .Where(u => (u.Role.Name == roleName || u.Role.Name == "Dietician-Trainer") &&
                            (searchPhrase == null ||
                             u.Name.ToLower().Contains(searchPhrase.ToLower()) ||
                             u.LastName.ToLower().Contains(searchPhrase.ToLower())));
        }



        //to do profilu wiec nie musi byc accepted
        public async Task<User?> GetUserWithDetailsAsync(int id, CancellationToken cancellationToken)
        =>  await _context.Users.Where(u=>u.IdUser==id)
            .Include(u => u.Role)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
        }

        public async Task<User?> GetUserByImageUri(string imageUri, CancellationToken cancellationToken)
        {
            return await _context.Users.Where(u => u.ImageUri == imageUri).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetPupilsByMentorIdAsync(int idMentor, CancellationToken cancellationToken)
        {
            return  await _context.Pupil_mentors.Where(pm => pm.IdMentor == idMentor && pm.IsAccepted == true)
                .Select(pm => pm.Pupil)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllUsersWithCertificatesAsync(bool isAccepted, CancellationToken cancellationToken)
        => await _context.Users
            .Where(c=>c.Certificates.Any(c=>c.IsAccepted == isAccepted)).ToListAsync(cancellationToken);
    }
}

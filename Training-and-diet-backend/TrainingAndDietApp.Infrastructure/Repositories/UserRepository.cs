using System.Linq.Expressions;
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
                    .Where(e => e.IdMentor == idTrainer)
                    .Select(e => e.IdPupil)
                    .Contains(u.IdUser))
                .ToListAsync(cancellationToken);
        }

        

        public async Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.IdUser == id, cancellationToken: cancellationToken);

            
        }

        public async Task<User?> GetUserWithGymsAndOpinionsAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.Include(u => u.MentorOpinions).ThenInclude(u => u.Pupil)
                .Include(u => u.TrainerGyms)
                .ThenInclude(tg => tg.Gym).ThenInclude(g => g.Address)
                .FirstOrDefaultAsync(u => u.IdUser == id, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AnyAsync(predicate);
        }

        public IQueryable<User> GetUsers(string? roleName, string? searchPhrase, CancellationToken cancellationToken)
        {
            return  _context.Users
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


        public async Task<bool> UserIsDietician(int dieticianId, CancellationToken cancellationToken)
        {

            return await _context.Users.Where(u => u.IdUser == dieticianId)
                .Select(u => u.Role)
                .AnyAsync(r => r.Name == "Dietician" || r.Name == "Dietician-Trainer", cancellationToken: cancellationToken);
        }

        public async Task<int> UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.IdUser;
        }
    }
}

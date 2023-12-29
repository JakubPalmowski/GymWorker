using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;

namespace TrainingAndDietApp.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetPupilsByTrainerIdAsync(int id_trainer);
        Task<User?> GetUserByIdAsync(int id);
    }
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
                    .Where(e => e.Id_Mentor == id_trainer)
                    .Select(e => e.Id_Pupil)
                    .Contains(u.Id_User))
                .ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user =  await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id_User == id);

            if(user == null)
                throw new NotFoundException("User with given id does not exist!");

            return user;
        }
    }
}

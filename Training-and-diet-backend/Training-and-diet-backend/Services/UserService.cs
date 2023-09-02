using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Controllers;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetPupilsByTrainerId(int id_trainer)
        {
            return await _context.Users.Where(u => _context.Pupil_mentors.Where(e => e.Id_Mentor == id_trainer).Select(e => e.Id_Pupil).Contains(u.Id_User)).ToListAsync();

        }

        public async Task<List<Exercise>> GetTrainerExercises(int TrainderId)
        {
            var query = await _context.Exercises.Where(e => e.Id_Trainer == TrainderId).ToListAsync();

            return query;

        }
        public async Task<List<Training_plan>> GetTrainerTrainingPlans(int id_trainer)
        {
            return await _context.Training_plans.Where(e => e.Id_Trainer == id_trainer).ToListAsync();
        }
    }
}

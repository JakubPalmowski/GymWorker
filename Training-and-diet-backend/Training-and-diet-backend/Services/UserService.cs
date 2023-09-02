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

        public Task<IQueryable<User>> GetPupilsByTrainerId(int TrainderId)
        {
            throw new NotImplementedException();
            /*var query = from user in _context.Users
                        join pupil_mentor in _context.Pupil_mentors
                        on TrainderId equals pupil_mentor.Id_Mentor
                        select new
                        {
                            user.Id_User,
                            user.Name,
                            user.Last_name,

                        };

            return query;*/
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

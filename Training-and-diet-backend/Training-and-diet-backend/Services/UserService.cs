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

        public IQueryable<User> GetPupilsByTrainerId(int TrainderId)
        {
            var query = from user in _context.Users
                        join pupil_mentor in _context.Pupil_mentors
                        on TrainderId equals pupil_mentor.Id_Mentor
                        select new { user.Id_User,  user.Name, user.Last_name
                        };

            return query;

        }
    }
}

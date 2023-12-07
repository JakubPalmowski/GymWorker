using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Controllers;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Exceptions;
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

            if (query.Count == 0)
                throw new NotFoundException("Trainer with given id was not found in database");

            return query;

        }
        public async Task<List<GetTrainingPlanGeneralInfoDTO>> GetTrainerTrainingPlans(int id_trainer)
        {
            var trainingPlans = await _context.Training_plans.Where(e => e.Id_Trainer == id_trainer).ToListAsync();
            var result = new List<GetTrainingPlanGeneralInfoDTO>();

            foreach (var trainingPlan in trainingPlans)
            {
                var dto = new GetTrainingPlanGeneralInfoDTO
                {
                    Id = trainingPlan.Id_Training_plan,
                    Name = trainingPlan.Name,
                    Duration = (int)(trainingPlan.End_date-trainingPlan.Start_date).TotalDays
                };

                result.Add(dto);
            }

            return result;

        }
    }
}

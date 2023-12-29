using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;

namespace Training_and_diet_backend.Repositories
{
    public interface ITrainingPlanRepository
    {
        Task<int> AddTrainingPlanAsync(Training_plan trainingPlan);
        Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int trainingPlanId);
        Task<List<Training_plan>> GetTrainingPlanByIdAsync(int trainingPlanId);
    }

    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTrainingPlanAsync(Training_plan trainingPlan)
        {
            _context.Training_plans.Add(trainingPlan);
            await _context.SaveChangesAsync();
            return trainingPlan.Id_Training_plan;
        }
        public async Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int trainingPlanId)
        {
            var planExercises = await _context.Trainee_exercises
                .Where(e => e.Id_Training_plan == trainingPlanId)
                .Select(e => e.Id_Exercise)
                .ToListAsync();

            return await _context.Exercises
                .Where(e => planExercises.Contains(e.Id_Exercise))
                .ToListAsync();
        }

        public async Task<List<Training_plan>> GetTrainingPlanByIdAsync(int trainingPlanId)
        {
           var trainingPlan =  await _context.Training_plans
                .Where(plan => plan.Id_Training_plan == trainingPlanId)
                .ToListAsync();

           return trainingPlan;
        }
    }
}

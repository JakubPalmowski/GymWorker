using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.Models;

namespace Training_and_diet_backend.Repositories
{
    public interface ITrainingPlanRepository
    {
        Task<int> AddTrainingPlanAsync(TrainingPlan trainingPlan);
        Task<List<TrainingPlan>> GetTrainingPlanByIdAsync(int trainingPlanId);

        Task<bool> CheckIfTrainingPlanExists(int trainingPlanId);
    }

    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTrainingPlanAsync(TrainingPlan trainingPlan)
        {
            _context.Training_plans.Add(trainingPlan);
            await _context.SaveChangesAsync();
            return trainingPlan.IdTrainingPlan;
        }

        public async Task<List<TrainingPlan>> GetTrainingPlanByIdAsync(int trainingPlanId)
        {
           var trainingPlan =  await _context.Training_plans
                .Where(plan => plan.IdTrainingPlan == trainingPlanId)
                .ToListAsync();

           return trainingPlan;
        }

        public async Task<bool> CheckIfTrainingPlanExists(int trainingPlanId)
        {
            var trainingPlan = await _context.Training_plans
                .Where(plan => plan.IdTrainingPlan == trainingPlanId)
                .ToListAsync();

            return trainingPlan.Any();
        }
    }
}

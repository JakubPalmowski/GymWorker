using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace Training_and_diet_backend.Repositories
{
    

    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTrainingPlanAsync(TrainingPlan trainingPlan, CancellationToken cancellationToken)
        {
            _context.Training_plans.Add(trainingPlan);
            await _context.SaveChangesAsync(cancellationToken);
            return trainingPlan.IdTrainingPlan;
        }

        public async Task<TrainingPlan?> GetTrainingPlanByIdAsync(int trainingPlanId, CancellationToken cancellationToken)
        {
           var trainingPlan =  await _context.Training_plans
                .Where(plan => plan.IdTrainingPlan == trainingPlanId)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

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

using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    

    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TrainingPlan>> GetTrainerTrainingPlans(int idTrainer, CancellationToken cancellationToken)
        {
            return await  _context.Training_plans.Where(e => e.IdTrainer == idTrainer).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<bool> CheckIfTrainingPlanExists(int trainingPlanId, CancellationToken cancellationToken)
        {
            var trainingPlan = await _context.Training_plans
                .Where(plan => plan.IdTrainingPlan == trainingPlanId)
                .ToListAsync(cancellationToken: cancellationToken);

            return trainingPlan.Any();
        }

    }
}

using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {

        private readonly ApplicationDbContext _context;

        public TrainingPlanService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTrainingPlan(Training_plan training_Plan)
        {
            _context.Training_plans.Add(training_Plan);
            await _context.SaveChangesAsync();
        }
    }
}

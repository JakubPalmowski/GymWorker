using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public interface ITrainingPlanService
    {
        Task AddTrainingPlan(Training_plan training_Plan);
    }
}

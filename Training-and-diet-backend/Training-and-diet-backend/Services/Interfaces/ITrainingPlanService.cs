using Training_and_diet_backend.Models;
using Training_and_diet_backend.DTOs;

namespace Training_and_diet_backend.Services
{
    public interface ITrainingPlanService
    {
        Task AddTrainingPlan(Training_plan training_Plan);

        Task <List<GetTrainingPlanByIdDTO>> GetTrainingPlanById (int trainingPlanId);
    }
}

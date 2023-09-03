using System.Numerics;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public interface ITrainingPlanService
    {
        Task AddTrainingPlan(Training_plan training_Plan);
        Task<List<GetExerciseGeneralInfoDTO>> GetExercisesFromTrainingPlan(int id_training_plan);

        Task<List<GetTrainingPlanByIdDTO>> GetTrainingPlanById(int trainingPlanId);


    }
}

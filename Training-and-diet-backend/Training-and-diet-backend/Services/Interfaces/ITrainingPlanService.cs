using System.Numerics;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public interface ITrainingPlanService
    {
        Task<int> AddTrainingPlan(PostTrainingPlanDTO training_PlanDTO);

        Task<List<GetExerciseGeneralInfoDTO>> GetExercisesFromTrainingPlan(int id_training_plan);

        Task<List<GetTrainingPlanByIdDTO>> GetTrainingPlanById(int trainingPlanId);
    }
}
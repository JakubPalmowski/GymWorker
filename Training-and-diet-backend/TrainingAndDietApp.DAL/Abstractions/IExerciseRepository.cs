using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId);

        Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan);
        Task<int> CreateExerciseAsync(Exercise exercise);
        Task<int> UpdateExerciseAsync(Exercise exercise);

        Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId);
        Task<bool> CheckIfExerciseExists(int trainingPlanId);

        Task<int> DeleteExerciseAsync(int exerciseId);
    }
}

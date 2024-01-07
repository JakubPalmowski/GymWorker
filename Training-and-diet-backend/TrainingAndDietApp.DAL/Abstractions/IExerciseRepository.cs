using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercisesAsync(CancellationToken cancellationToken);
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId, CancellationToken cancellation);

        Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellation);
        Task<int> CreateExerciseAsync(Exercise exercise, CancellationToken cancellation);
        Task<int> UpdateExerciseAsync(Exercise exercise, CancellationToken cancellation);

        Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId, CancellationToken cancellation);
        Task<bool> CheckIfExerciseExists(int trainingPlanId);

        Task<int> DeleteExerciseAsync(int exerciseId, CancellationToken cancellation);
    }
}

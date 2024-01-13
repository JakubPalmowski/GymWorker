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
        Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellation);
        Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId, CancellationToken cancellation);
        Task<bool> CheckIfExerciseExists(int trainingPlanId);

    }
}

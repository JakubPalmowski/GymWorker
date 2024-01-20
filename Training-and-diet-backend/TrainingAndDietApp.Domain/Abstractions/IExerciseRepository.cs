using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellation);
        Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId, CancellationToken cancellation);
        Task<bool> CheckIfExerciseExists(int trainingPlanId);

        Task<List<Exercise>> GetSystemExercisesAsync(CancellationToken cancellation);

    }
}

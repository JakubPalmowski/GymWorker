using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface ITraineeExercisesRepository
    {
        Task<TraineeExercise?> GetTraineeExerciseWithExerciseByIdAsync(int idTraineeExercise,
            CancellationToken cancellationToken);
        Task<IEnumerable<TraineeExercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellationToken);
    }
}

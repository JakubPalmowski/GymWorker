using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface ITraineeExercisesRepository
    {
        Task<int> AddTraineeExercisesAsync(TraineeExercise traineeExercise, CancellationToken cancellationToken);
        Task<bool> CheckIfTraineeExerciseExistsAsync(int idTraineeExercise, CancellationToken cancellationToken);
        Task <TraineeExercise?> GetTraineeExerciseByIdAsync(int idTraineeExercise, CancellationToken cancellationToken);
        Task UpdateTraineeExerciseAsync(TraineeExercise traineeExercise, CancellationToken cancellationToken);

    }
}

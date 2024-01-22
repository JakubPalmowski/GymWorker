using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface ITraineeExercisesRepository
    {
        Task<TraineeExercise?> GetTrainerTraineeExerciseWithExerciseByIdAsync(int idTraineeExercise,int idTrainer, CancellationToken cancellationToken);
        Task<IEnumerable<TraineeExercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellationToken);
        Task<TraineeExercise?> GetTraineeExerciseWithTrainingPlanAndTrainerByIdAsync(int idTrainingPlan, CancellationToken cancellationToken);
        Task<TraineeExercise?> GetTraineeExerciseWithTrainingPlanAndPupilByIdAsync(int idTrainingPlan, CancellationToken cancellationToken);

        Task<TraineeExercise?> GetPupilTraineeExerciseWithExerciseByIdAsync(int idTraineeExercise, int idPupil,
            CancellationToken cancellationToken);
    }
}

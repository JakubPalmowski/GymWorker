namespace TrainingAndDietApp.Application.Abstractions;

public interface ITraineeExerciseAccessService
{
    Task<bool> IsAccessibleByTrainer(int idTraineeExercise, int mentorId, CancellationToken cancellationToken);
    Task<bool> IsAccessibleByPupil(int idTraineeExercise, int pupilId, CancellationToken cancellation);
}
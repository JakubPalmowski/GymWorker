namespace TrainingAndDietApp.Application.Abstractions;

public interface ITrainingPlanAccessService
{
    Task<bool> IsAccessibleByTrainer(int idTrainingPlan, int mentorId, CancellationToken cancellationToken);
    Task<bool> IsAccessibleByPupil(int trainingPlanId, int pupilId, CancellationToken cancellation);
}
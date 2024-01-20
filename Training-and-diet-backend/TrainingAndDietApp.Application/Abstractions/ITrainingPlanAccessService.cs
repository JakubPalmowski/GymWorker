namespace TrainingAndDietApp.Application.Abstractions;

public interface ITrainingPlanAccessService
{
    Task<bool> IsAccessibleBy(int idTrainingPlan, int mentorId, CancellationToken cancellationToken);
}
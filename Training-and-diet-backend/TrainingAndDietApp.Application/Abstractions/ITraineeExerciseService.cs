namespace TrainingAndDietApp.Application.Abstractions;

public interface ITraineeExerciseService
{
    Task<bool> IsTrainingPlanValid (int idTrainingPlan);
    Task <bool> IsExerciseValid (int idExercise);
}
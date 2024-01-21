using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById.Pupil;

public record GetPupilTraineeExerciseQuery(int IdTraineeExercise, int LoggedUser) : IRequest<PupilTraineeExerciseResponse>
{
    
}

public class PupilTraineeExerciseResponse
{
    public int IdTraineeExercise { get; set; }
    public string SeriesNumber { get; set; }
    public string RepetitionsNumber { get; set; }
    public string Comments { get; set; }
    public int IdExercise { get; set; }
    public int IdTrainingPlan { get; set; }
    public string ExerciseName { get; set; }
    public string Details { get; set; }
    public string ExerciseSteps { get; set; }
}
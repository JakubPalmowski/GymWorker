using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.CreateTraineeExercise;

public class CreateTraineeExerciseCommand : IRequest<CreateTraineeExerciseResponse>
{
    public int SeriesNumber { get; set; }
    public string RepetitionsNumber { get; set; }
    public string? Comments { get; set; }
    public int DayOfWeek { get; set; }
    public int IdExercise { get; set; }
    public int IdTrainingPlan { get; set; }
}
public class CreateTraineeExerciseResponse
{
    public int IdTraineeExercise { get; set; }
}
using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;

namespace TrainingAndDietApp.Application.Commands.TraineeExercises;

public class CreateTraineeExerciseCommand : IRequest<CreateTraineeExerciseResponse>
{
    public int SeriesNumber { get; set; }
    public string RepetitionsNumber { get; set; }
    public string? Comments { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int IdExercise { get; set; }
    public int IdTrainingPlan { get; set; }
}
public class CreateTraineeExerciseResponse
{
    public int IdTraineeExercise { get; set; }
}
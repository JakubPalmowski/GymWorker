using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.UpdateTraineeExercise;

public class UpdateTraineeExerciseCommand : IRequest
{
    public UpdateTraineeExerciseCommand(int seriesNumber, string repetitionsNumber, string? comments, int dayOfWeek)
    {
        SeriesNumber = seriesNumber;
        RepetitionsNumber = repetitionsNumber;
        Comments = comments;
        DayOfWeek = dayOfWeek;
    }

    public int SeriesNumber { get; set; }
    public string RepetitionsNumber { get; set; }
    public string? Comments { get; set; }
    public int DayOfWeek { get; set; }
}



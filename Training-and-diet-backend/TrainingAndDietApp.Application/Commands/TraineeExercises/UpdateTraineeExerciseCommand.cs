using MediatR;

namespace TrainingAndDietApp.Application.Commands.TraineeExercises;

public class UpdateTraineeExerciseCommand : IRequest
{
    public UpdateTraineeExerciseCommand(int seriesNumber, string repetitionsNumber, string? comments, DayOfWeek dayOfWeek)
    {
        SeriesNumber = seriesNumber;
        RepetitionsNumber = repetitionsNumber;
        Comments = comments;
        DayOfWeek = dayOfWeek;
    }

    public int SeriesNumber { get; set; }
    public string RepetitionsNumber { get; set; }
    public string? Comments { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}

    

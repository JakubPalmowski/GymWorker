namespace TrainingAndDietApp.Application.Responses.TraineeExercise;

public class TraineeExerciseResponse
{
    public string IdTraineeExercise { get; set; }
    public string SeriesNumber { get; set; }
    public string RepetitionsNumber { get; set; }
    public string ExerciseName { get; set; }
    public string? Comments { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int IdExercise { get; set; }
    public int IdTrainingPlan { get; set; }

}
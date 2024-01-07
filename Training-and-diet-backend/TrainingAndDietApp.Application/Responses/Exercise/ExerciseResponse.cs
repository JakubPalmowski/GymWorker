namespace TrainingAndDietApp.Application.Responses.Exercise;

public class ExerciseResponse
{
    public int IdExercise { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public string ExerciseSteps { get; set; }
    public byte[]? Image { get; set; }
    public int? IdTrainer { get; set; }
}
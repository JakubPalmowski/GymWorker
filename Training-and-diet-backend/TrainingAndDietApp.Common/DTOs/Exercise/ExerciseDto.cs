namespace TrainingAndDietApp.Common.DTOs.Exercise
{
    public class ExerciseDto
    {
        public int IdExercise { get; private set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ExerciseSteps { get; set; }
        public byte[]? Image { get; set; }
        public int? IdTrainer { get; set; }
    }
}

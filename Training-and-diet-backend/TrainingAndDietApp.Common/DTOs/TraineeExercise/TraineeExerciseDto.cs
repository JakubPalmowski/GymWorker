namespace Training_and_diet_backend.DTOs.TraineeExercise
{
    public class TraineeExerciseDto
    {
        public int SeriesNumber { get; set; }
        public int RepetitionsNumber { get; set; }
        public string? Comments { get; set; }
        public DateTime Date { get; set; }
        public int IdExercise { get; set; }
        public int IdTrainingPlan { get; set; }

    }
}

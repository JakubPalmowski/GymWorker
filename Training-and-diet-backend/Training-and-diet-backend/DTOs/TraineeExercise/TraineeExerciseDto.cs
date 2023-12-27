namespace Training_and_diet_backend.DTOs.TraineeExercise
{
    public class TraineeExerciseDto
    {
        public int Series_Number { get; set; }
        public int Repetitions_number { get; set; }
        public string? Comments { get; set; }
        public DateTime Date { get; set; }
        public int Id_Exercise { get; set; }
        public int Id_Training_plan { get; set; }

    }
}

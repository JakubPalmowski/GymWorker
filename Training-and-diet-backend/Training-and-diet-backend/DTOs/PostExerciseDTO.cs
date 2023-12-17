namespace Training_and_diet_backend.DTOs
{
    public class PostExerciseDTO
    {
        public int Id_Exercise { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Exercise_steps { get; set; }
        public byte[]? Image { get; set; }
        public int Id_Trainer { get; set; }
    }
}

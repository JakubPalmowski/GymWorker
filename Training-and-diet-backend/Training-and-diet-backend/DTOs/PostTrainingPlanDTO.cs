namespace Training_and_diet_backend.DTOs
{
    public class PostTrainingPlanDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public int Id_Trainer { get; set; }
    }
}

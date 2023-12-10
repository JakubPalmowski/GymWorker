namespace Training_and_diet_backend.DTOs
{
    public class GetTrainingPlanByIdDTO
    {
        public int Id_Training_plan { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

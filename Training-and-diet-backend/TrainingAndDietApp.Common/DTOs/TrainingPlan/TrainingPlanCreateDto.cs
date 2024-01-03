

namespace Training_and_diet_backend.DTOs.TrainingPlan
{
    public class TrainingPlanCreateDto
    {
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdTrainer { get; set; }
    }
}

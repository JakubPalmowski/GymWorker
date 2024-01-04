namespace Training_and_diet_backend.DTOs.TrainingPlan
{
    public class TrainingPlanNameDto
    {
        public int IdTrainingPlan { get; set; }
        public string Name { get; set; }

        public string CustomName { get; set; }
        public int PlanDuration { get; set; }
    }
}

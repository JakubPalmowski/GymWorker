using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.DTOs.TrainingPlan
{
    public class TrainingPlanDetailsDto
    {
        public int IdTrainingPlan { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        public int? PlanDuration { get; set; }

    }
}

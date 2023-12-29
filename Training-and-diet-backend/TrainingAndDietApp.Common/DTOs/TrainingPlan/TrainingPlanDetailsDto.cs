using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.DTOs.TrainingPlan
{
    public class TrainingPlanDetailsDto
    {
        public int Id_Training_plan { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Start_date { get; set; }

        [Column(TypeName = "Date")]
        public DateTime End_date { get; set; }

        public int? Plan_Duration { get; set; }

    }
}

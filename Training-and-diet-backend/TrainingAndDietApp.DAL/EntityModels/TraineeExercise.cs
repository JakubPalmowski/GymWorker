using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Training_and_diet_backend.Models
{
    public class TraineeExercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdTraineeExercise { get; set; }
        public int SeriesNumber { get; set; }
        public int RepetitionsNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Comments { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [ForeignKey("Exercise")]
        public int IdExercise { get; set; }
        [ForeignKey("TrainingPlan")]
        public int IdTrainingPlan { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual TrainingPlan TrainingPlan { get; set; }
    }
}

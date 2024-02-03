using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Domain.Entities
{
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdExercise { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Details { get; set; }
        [Column(TypeName = "varchar(300)")]
        [Required]
        public string ExerciseSteps { get; set; }

        [ForeignKey("Trainer")]
        public int? IdTrainer { get; set; }
        public virtual User? Trainer { get; set; }
        public virtual ICollection<TraineeExercise> TraineeExercises { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.DAL.Models
{
    public class TrainingPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdTrainingPlan { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CustomName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Type { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        public int NumberOfWeeks { get; set; }

        [ForeignKey("Trainer")]
        public int IdTrainer { get; set; }
        [ForeignKey("Pupil")]
        public int? IdPupil { get; set; }

        public virtual User Trainer { get; set; }

        public virtual User Pupil { get; set; }

        public virtual ICollection<TraineeExercise> TraineeExercises { get; set; }

        
      
    }  
}

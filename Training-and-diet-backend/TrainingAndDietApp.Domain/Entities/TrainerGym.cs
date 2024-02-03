using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingAndDietApp.Domain.Entities;

namespace Training_and_diet_backend.Models
{
  
    public class TrainerGym
    {
        [Key]
        [Column(Order = 0)]
        public int IdGym { get; set; }
        [Key]
        [Column(Order = 1)]
        public int IdTrainer { get; set; }

        [ForeignKey("IdGym")]
        public virtual Gym Gym { get; set; }

        [ForeignKey("IdTrainer")]
        public virtual User Trainer { get; set; }
    }
}

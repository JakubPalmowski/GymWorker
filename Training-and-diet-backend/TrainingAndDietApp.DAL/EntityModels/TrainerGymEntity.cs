using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    [Table("TrainerGym")]
    public class TrainerGymEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdTrainerGym { get; set; }
        public int IdGym { get; set; }
        public int IdTrainer { get; set; }

        [ForeignKey("IdGym")]
        public virtual GymEntity GymEntity { get; set; }

        [ForeignKey("IdTrainer")]
        public virtual UserEntity Trainer { get; set; }
    }
}

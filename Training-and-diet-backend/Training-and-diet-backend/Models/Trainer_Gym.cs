using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Trainer_Gym
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Trainer_Gym { get; set; }
        public int Id_Gym { get; set; }
        public int Id_Trainer { get; set; }

        [ForeignKey("Id_Gym")]
        public virtual Gym Gym { get; set; }

        [ForeignKey("Id_Trainer")]
        public virtual User Trainer { get; set; }
    }
}

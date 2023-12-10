using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Gym
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Gym { get; set; }

        public int Id_Address { get; set; }
        public string Name { get; set; }


        [ForeignKey("Id_Address")]
        public virtual Address Address { get; set; }

        public virtual ICollection<Trainer_Gym> Gyms { get; set; }


    }
}

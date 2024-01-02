using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    [Table("Gym")]
    public class GymEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdGym { get; set; }

        public int IdAddress { get; set; }
        public string Name { get; set; }


        [ForeignKey("IdAddress")]
        public virtual AddressEntity AddressEntity { get; set; }

        public virtual ICollection<TrainerGymEntity> TrainerGyms { get; set; }


    }
}

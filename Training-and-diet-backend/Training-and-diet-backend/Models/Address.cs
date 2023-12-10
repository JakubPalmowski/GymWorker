using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Address { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Street { get; set; }
        [Column(TypeName = "char(6)")]
        public string Postal_code { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Gym> Gyms { get; set; }

        
    }
}

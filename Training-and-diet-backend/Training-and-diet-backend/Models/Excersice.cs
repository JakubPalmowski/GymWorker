using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Exercise { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public string Details { get; set; }

        [Column(TypeName = "jsonb")]
        public string Exercise_steps { get; set; }

        public byte[]? Image { get; set; }
        public virtual ICollection<Trainee_exercise> Trainee_Exercises { get; set; }
    }
}

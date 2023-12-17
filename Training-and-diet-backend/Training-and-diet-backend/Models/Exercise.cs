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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string Exercise_steps { get; set; }

        public byte[]? Image { get; set; }

        [ForeignKey("Trainer")]
        public int Id_Trainer { get; set; }
        public virtual User Trainer { get; set; }
        public virtual ICollection<Trainee_exercise> Trainee_Exercises { get; set; }
    }
}

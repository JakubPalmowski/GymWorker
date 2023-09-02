using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Training_plan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Training_plan { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Type { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Start_date { get; set; }
        [Column(TypeName = "Date")]
        public DateTime End_date { get; set; }
        public TimeSpan Plan_duration { get; set; }

        [ForeignKey("Trainer")]
        public int Id_Trainer { get; set; }
        [ForeignKey("Pupil")]
        public int? Id_Pupil { get; set; }

        public virtual User Trainer { get; set; }

        public virtual User Pupil { get; set; }

        public virtual ICollection<Trainee_exercise> Trainee_Exercises { get; set; }
    }
}

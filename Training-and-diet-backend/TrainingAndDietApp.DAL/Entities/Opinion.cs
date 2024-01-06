using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingAndDietApp.Domain.Entities;

namespace Training_and_diet_backend.Models
{
    [Table("Opinion")]
    public class Opinion
    {

        [ForeignKey("Pupil")]
        public int IdPupil { get; set; }

        [ForeignKey("Mentor")]
        public int IdMentor { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Content { get; set; }

        [Column(TypeName = "Date")]
        public DateTime OpinionDate { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public decimal Rate { get; set; }
        public virtual User Mentor { get; set; }

        public virtual User Pupil { get; set; }
    }
}

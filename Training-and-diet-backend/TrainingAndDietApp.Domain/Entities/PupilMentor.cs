using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Entities
{
    public class PupilMentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        [ForeignKey("Mentor")]
        public int IdMentor { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        [ForeignKey("Pupil")]
        public int IdPupil { get; set; }
        public bool IsAccepted { get; set; } = false;

        public virtual User Mentor { get; set; }

        public virtual User Pupil { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Entities
{
    public class PupilMentor
    {
        public int IdMentor { get; set; }
        public int IdPupil { get; set; }

        public bool IsAccepted { get; set; } = false;

        [ForeignKey("IdMentor")]
        public virtual User Mentor { get; set; }

        [ForeignKey("IdPupil")]
        public virtual User Pupil { get; set; }
    }
}

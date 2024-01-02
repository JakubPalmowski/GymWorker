using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.DAL.EntityModels
{
    [Table("PupilMentor")]
    public class PupilMentorEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        [ForeignKey("Mentor")]
        public int IdMentor { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        [ForeignKey("Pupil")]
        public int IdPupil { get; set; }

        public virtual UserEntity Mentor { get; set; }

        public virtual UserEntity Pupil { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingAndDietApp.DAL.EntityModels;

namespace Training_and_diet_backend.Models
{
    [Table("User")]
    public class UserEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "char(11)")]
        public string PhoneNumber { get; set; }
        public bool EmailValidated { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal? Height { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Sex { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Bio { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal? TrainingPlanPriceFrom { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? TrainingPlanPriceTo { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? PersonalTrainingPriceFrom { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? PersonalTrainingPriceTo { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? DietPriceFrom { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? DietPriceTo { get; set; }


        [InverseProperty("Pupil")]
        public virtual ICollection<TrainingPlanEntity> PupilTrainingPlans { get; set; }
        [InverseProperty("Trainer")]
        public virtual ICollection<TrainingPlanEntity> TrainerTrainingPlans { get; set; }
        public virtual ICollection<ExerciseEntity> Exercises { get; set; }


        [InverseProperty("Pupil")]
        public virtual ICollection<PupilMentorEntity> PupilMentors { get; set; }
        [InverseProperty("Mentor")]
        public virtual ICollection<PupilMentorEntity> MentorPupils { get; set; }
        public virtual ICollection<DietEntity> DietsAsDietician { get; set; }
        public virtual ICollection<DietEntity> DietsAsPupil { get; set; }

        [ForeignKey("IdRole")]
        public virtual RoleEntity RoleEntity { get; set; }

        public int IdRole { get; set; }

        [InverseProperty("Mentor")]
        public virtual ICollection<OpinionEntity> MentorOpinions { get; set; }

        [InverseProperty("Pupil")]
        public virtual ICollection<OpinionEntity> PupilOpinions { get; set; }

        public virtual ICollection<TrainerGymEntity> TrainerGyms { get; set; }


    }
}

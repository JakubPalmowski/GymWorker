using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
using Training_and_diet_backend.Models;



namespace TrainingAndDietApp.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdUser { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirationDate { get; set; }
        public string? ImageUri { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Height { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? Sex { get; set; }
        [Column(TypeName = "varchar(1500)")]
        public string? Bio { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal? TrainingPlanPriceFrom { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? TrainingPlanPriceTo { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? PersonalTrainingPriceFrom { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? PersonalTrainingPriceTo { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? DietPriceFrom { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? DietPriceTo { get; set; }
        public bool IsAccepted { get; set; } = false;



        public virtual ICollection<Certificate> Certificates { get; set; }

        [InverseProperty("Pupil")]
        public virtual ICollection<TrainingPlan> PupilTrainingPlans { get; set; }
        [InverseProperty("Trainer")]
        public virtual ICollection<TrainingPlan> TrainerTrainingPlans { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }


        [InverseProperty("Pupil")]
        public virtual ICollection<PupilMentor> PupilMentors { get; set; }
        [InverseProperty("Mentor")]
        public virtual ICollection<PupilMentor> MentorPupils { get; set; }
        public virtual ICollection<Diet> DietsAsDietician { get; set; }
        public virtual ICollection<Diet> DietsAsPupil { get; set; }

        [ForeignKey("IdRole")]
        public virtual Role Role { get; set; }

        public int IdRole { get; set; }

        [InverseProperty("Mentor")]
        public virtual ICollection<Opinion> MentorOpinions { get; set; }

        [InverseProperty("Pupil")]
        public virtual ICollection<Opinion> PupilOpinions { get; set; }

        public virtual ICollection<TrainerGym> TrainerGyms { get; set; }


    }
}

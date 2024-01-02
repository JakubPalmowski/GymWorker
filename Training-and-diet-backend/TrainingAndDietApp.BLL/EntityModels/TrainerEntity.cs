using TrainingAndDietApp.BLL.Models;

namespace TrainingAndDietApp.BLL.EntityModels
{
    public class TrainerEntity
    {
        public int IdUser { get; set; }
        public RoleValueObject RoleValueObject { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailValidated { get; set; }
  
        public decimal? Weight { get; set; }
     
        public decimal? Height { get; set; }
        public int? Age { get; set; }

        public string Sex { get; set; }
      
        public string Bio { get; set; }

        public decimal? TrainingPlanPriceFrom { get; set; }
  
        public decimal? TrainingPlanPriceTo { get; set; }
    
        public decimal? PersonalTrainingPriceFrom { get; set; }
     
        public decimal? PersonalTrainingPriceTo { get; set; }

        public virtual ICollection<TrainingPlanEntity> TrainerTrainingPlans { get; set; }
        public virtual ICollection<ExerciseEntity> Exercises { get; set; }
        public virtual ICollection<PupilMentorEntity> MentorPupils { get; set; }
        public virtual ICollection<OpinionEntity> MentorOpinions { get; set; }
        public virtual ICollection<TrainerGymEntity> TrainerGyms { get; set; }
    }
}

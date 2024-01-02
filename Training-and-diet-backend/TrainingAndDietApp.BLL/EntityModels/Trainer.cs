using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.EntityModels;

namespace TrainingAndDietApp.BLL.Models
{
    public class Trainer
    {
        public int IdUser { get; set; }
        public Role Role { get; set; }
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

        public virtual ICollection<TrainingPlan> TrainerTrainingPlans { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<PupilMentor> MentorPupils { get; set; }
        public virtual ICollection<Opinion> MentorOpinions { get; set; }
        public virtual ICollection<TrainerGym> TrainerGyms { get; set; }
    }
}

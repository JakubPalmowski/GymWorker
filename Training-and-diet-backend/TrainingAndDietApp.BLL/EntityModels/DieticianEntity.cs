using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.EntityModels;
using System.Data;

namespace TrainingAndDietApp.BLL.Models
{
    public class DieticianEntity
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
        public decimal? DietPriceFrom { get; set; }
        public decimal? DietPriceTo { get; set; }
        public virtual ICollection<PupilMentorEntity> MentorPupils { get; set; }
        public virtual ICollection<DietEntity> DietsAsDietician { get; set; }
        public virtual ICollection<OpinionEntity> MentorOpinions { get; set; }

    }
}

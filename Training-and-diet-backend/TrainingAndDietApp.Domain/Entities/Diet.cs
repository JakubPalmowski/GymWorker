using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Entities
{
    public class Diet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdDiet { get; set; }
        [Required]
        public int IdDietician { get; set; }
        public int? IdPupil { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
     
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
      
        [Column(TypeName = "varchar(50)")]
        public string CustomName { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string Type { get; set; }
        
        public int NumberOfWeeks { get; set; }
        public int TotalKcal { get; set; }

        [ForeignKey("IdDietician")]
        public virtual User Dietician { get; set; }
        [ForeignKey("IdPupil")]
        public virtual User Pupil { get; set; }

        public virtual ICollection<MealDiet> MealsInDiet { get; set; }
    }
}

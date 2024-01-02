using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.DAL.EntityModels
{
    [Table("Diet")]
    public class DietEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdDiet { get; set; }
        [Required]
        public int IdDietician { get; set; }
        [Required]
        public int IdPupil { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public string DietDuration { get; set; }
        public int TotalKcal { get; set; }

        [ForeignKey("IdDietician")]
        public virtual UserEntity Dietician { get; set; }
        [ForeignKey("IdPupil")]
        public virtual UserEntity Pupil { get; set; }

        public virtual ICollection<MealDietEntity> MealsInDiet { get; set; }
    }
}

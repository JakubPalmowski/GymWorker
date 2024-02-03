using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Domain.Entities
{
    public class Meal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdMeal { get; set; }

        public int IdDietician { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Ingredients { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string PrepareSteps { get; set; }
        public string Kcal { get; set; }
        [ForeignKey("IdDietician")]
        public virtual User Dietician { get; set; }

        public virtual ICollection<MealDiet> Meals { get; set; }
    }
}
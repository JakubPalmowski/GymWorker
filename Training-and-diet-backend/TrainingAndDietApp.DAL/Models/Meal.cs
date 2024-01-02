using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Meal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdMeal { get; set; }

        public int IdDietician { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string PrepareSteps { get; set; }
        public byte[]? Image { get; set; }

        public string Kcal { get; set; }
        [ForeignKey("IdDietician")]
        public virtual User Dietetician { get; set; }

        public virtual ICollection<MealDiet> Meals { get; set; }
    }
}
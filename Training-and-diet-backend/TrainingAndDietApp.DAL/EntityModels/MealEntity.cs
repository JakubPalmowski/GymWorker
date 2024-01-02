using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    [Table("Meal")]
    public class MealEntity
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
        public virtual UserEntity Dietetician { get; set; }

        public virtual ICollection<MealDietEntity> Meals { get; set; }
    }
}
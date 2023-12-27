using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Meal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Meal { get; set; }

        public int Id_Dietetician { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Prepare_Steps { get; set; }
        public byte[]? Image { get; set; }

        public string Kcal { get; set; }
        [ForeignKey("Id_Dietetician")]
        public virtual User Dietetician { get; set; }

        public virtual ICollection<Meal_Diet> Meals { get; set; }
    }
}
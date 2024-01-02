using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.DTOs.MealDto
{
    public class MealDto
    {
        public int IdMeal { get; set; }
        public int IdDietician { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string PrepareSteps { get; set; }
        public byte[]? Image { get; set; }
        public string Kcal { get; set; }
    }
}
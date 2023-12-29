using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.DTOs.MealDto
{
    public class MealDto
    {
        public int Id_Meal { get; set; }
        public int Id_Dietetician { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Prepare_Steps { get; set; }
        public byte[]? Image { get; set; }
        public string Kcal { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Entities
{
    public class MealDiet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdMealDiet { get; set; }
     
        public int IdMeal { get; set; }
    
        public int IdDiet { get; set; }
        //nowe
        public int DayOfWeek { get; set; }
        //nowe
        [Column(TypeName = "varchar(5)")]
        public string HourOfMeal { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? Comments { get; set; }
        [ForeignKey("IdMeal")]
        public virtual Meal Meal { get; set; }
        [ForeignKey("IdDiet")]
        public virtual Diet Diet { get; set; }

       

    }
}

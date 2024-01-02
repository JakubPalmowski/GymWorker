using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingAndDietApp.DAL.EntityModels;

namespace Training_and_diet_backend.Models
{
    [Table("MealDiet")]
    public class MealDietEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdMealDiet { get; set; }
     
        public int IdMeal { get; set; }
    
        public int IdDiet { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Comments { get; set; }
        [ForeignKey("IdMeal")]
        public virtual MealEntity MealEntity { get; set; }
        [ForeignKey("IdDiet")]
        public virtual DietEntity DietEntity { get; set; }

       

    }
}

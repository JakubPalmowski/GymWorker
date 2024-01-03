using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.BLL.Models
{
    public class MealEntity
    {
        public int IdMeal { get; set; }
        public int IdDietician { get; set; }
        public DieticianEntity Dietician { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string PrepareSteps { get; set; }
        public byte[]? Image { get; set; }
        public string Kcal { get; set; }
       /* public virtual ICollection<Meal_DietDomainModel> Meals { get; set;}*/


       public bool CheckIfDietician()
       {
            return Dietician.RoleValueObject.Name.Equals("Dietician");
          
       }


       
    }
}

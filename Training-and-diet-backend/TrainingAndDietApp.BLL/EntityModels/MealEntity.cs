using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.BLL.Models
{
    public class MealEntity
    {
        public int Id_Meal { get; set; }
        public int Id_Dietetician { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Prepare_Steps { get; set; }
        public byte[]? Image { get; set; }
        public string Kcal { get; set; }
       /* public virtual ICollection<Meal_DietDomainModel> Meals { get; set;}*/

       
    }
}

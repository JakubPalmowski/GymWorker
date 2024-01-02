using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.BLL.Models
{
    public class Diet
    {
        public int IdDiet { get; set; }
        public Dietician Dietician { get; set; }
        public Pupil Pupil { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DietDuration => (EndDate - StartDate).ToString();
        public int TotalKcal { get; set; }
      /*  public virtual ICollection<> MealsInDiet { get; set; }*/
    }
}

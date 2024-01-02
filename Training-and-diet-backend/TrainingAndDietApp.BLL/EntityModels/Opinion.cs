using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.BLL.Models
{
    public class Opinion
    {
        public string Content { get; set; }
        public DateTime OpinionDate { get; set; }
        public decimal Rate { get; set; }
        /*public virtual Mentor Mentor { get; set; }*/


        public virtual Pupil Pupil { get; set; }
    }
}
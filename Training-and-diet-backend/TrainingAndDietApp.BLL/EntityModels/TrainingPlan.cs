using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.BLL.Models
{
    public class TrainingPlan
    {
        public int IdTrainingPlan { get; set; }

        public string Name { get; set; }
       
        public string Type { get; set; }
    
        public DateTime StartDate { get; set; }
     
        public DateTime EndDate { get; set; }

        public int PlanDuration => (EndDate - StartDate).Days;

        public virtual Trainer Trainer { get; set; }
        public virtual Pupil? Pupil { get; set; }

        public virtual ICollection<TraineeExercise> TraineeExercises { get; set; }
    }
}

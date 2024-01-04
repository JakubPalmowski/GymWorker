using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.BLL.EntityModels;

namespace TrainingAndDietApp.BLL.Models
{
    public class TraineeExerciseEntity
    {
        public int IdTraineeExercise { get; set; }
        public int IdExercise { get; set; }
        public int IdTrainingPlan { get; set; }
        public int SeriesNumber { get; set; }
        public string RepetitionsNumber { get; set; }
        public string? Comments { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public ExerciseEntity ExerciseEntity { get; set; }
        public TrainingPlanEntity TrainingPlanEntity { get; set; }
        

    }
}

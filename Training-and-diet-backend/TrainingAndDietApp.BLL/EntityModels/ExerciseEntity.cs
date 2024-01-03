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
    public class ExerciseEntity
    {
        public int IdExercise { get; set; }
    
        public string Name { get; set; }

        public string Details { get; set; }

        public string ExerciseSteps { get; set; }

        public byte[]? Image { get; set; }

        public TrainerEntity? Trainer { get; set; }
        public virtual ICollection<TraineeExerciseEntity> TraineeExercises { get; set; }
    }
}

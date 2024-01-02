﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.BLL.Models
{
    public class Exercise
    {
        public int IdExercise { get; set; }
    
        public string Name { get; set; }

        public string Details { get; set; }

        public string ExerciseSteps { get; set; }

        public byte[]? Image { get; set; }

        public Trainer? Trainer { get; set; }
        public virtual ICollection<TraineeExercise> TraineeExercises { get; set; }
    }
}

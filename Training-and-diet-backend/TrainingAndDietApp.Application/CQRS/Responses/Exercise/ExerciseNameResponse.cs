using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Application.CQRS.Responses.Exercise
{
    public class ExerciseNameResponse
    {
        public string Name { get; set; }
        public int IdExercise { get; set; }
    }
}
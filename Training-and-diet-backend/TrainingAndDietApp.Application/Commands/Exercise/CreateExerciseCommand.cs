using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Application.Responses.Meal;

namespace TrainingAndDietApp.Application.Commands.Exercise
{
    public class CreateExerciseCommand : IRequest<ExerciseNameResponse>
    {
       

        public string Name { get; set; }
        public string Details { get; set; }
        public string ExerciseSteps { get; set; }
        public byte[]? Image { get; set; }
        public int IdTrainer { get; set; }


    }
}
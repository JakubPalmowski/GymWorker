using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrainingAndDietApp.Application.Commands.Exercise
{
    public class DeleteExerciseCommand : IRequest
    {
        public int IdExercise { get; set; }

        public DeleteExerciseCommand(int idExercise)
        {
            IdExercise = idExercise;
        }
    }
}

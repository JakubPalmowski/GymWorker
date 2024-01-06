using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;

namespace TrainingAndDietApp.Application.Queries.Exercise
{
    public class GetExerciseQuery : IRequest<ExerciseResponse>
    {
        public GetExerciseQuery(int idExercise)
        {
            IdExercise = idExercise;
        }
        public int IdExercise { get; set; }

    }
}
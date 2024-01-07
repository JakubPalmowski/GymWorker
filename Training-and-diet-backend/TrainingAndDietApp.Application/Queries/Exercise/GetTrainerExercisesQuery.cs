using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;

namespace TrainingAndDietApp.Application.Queries.Exercise
{
    public record GetTrainerExercisesQuery (int TrainerId) : IRequest<IEnumerable<ExerciseNameResponse>>
    {
    }
}

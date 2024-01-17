using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainerId
{
    public record GetTrainerExercisesQuery(int TrainerId) : IRequest<IEnumerable<ExerciseNameResponse>>
    {
    }
}

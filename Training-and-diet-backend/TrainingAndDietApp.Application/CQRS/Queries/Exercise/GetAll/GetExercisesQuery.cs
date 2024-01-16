using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetAll;

public class GetExercisesQuery : IRequest<IEnumerable<ExerciseNameResponse>>
{
}
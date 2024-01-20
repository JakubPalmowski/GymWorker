using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetAll;

public class GetSystemExercisesQuery : IRequest<IEnumerable<ExerciseNameResponse>>
{
}
using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;

namespace TrainingAndDietApp.Application.Queries.Exercise;

public class GetExercisesQuery : IRequest<IEnumerable<ExerciseResponse>>
{
}
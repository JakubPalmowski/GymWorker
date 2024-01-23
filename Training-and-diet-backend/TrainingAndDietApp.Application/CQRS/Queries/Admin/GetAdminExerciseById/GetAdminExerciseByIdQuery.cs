using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAdminExerciseById
{
    public record GetAdminExerciseByIdQuery(int IdExercise) : IRequest<ExerciseResponse>
    {

    }
}

using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllGymsAdmin
{
    public class GetAllExercisesAdminQuery : IRequest<List<ExerciseNameResponse>>
    {
    
    }
}

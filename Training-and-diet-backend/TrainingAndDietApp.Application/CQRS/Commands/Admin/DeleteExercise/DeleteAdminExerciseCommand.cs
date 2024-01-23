using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteExercise
{
    public record DeleteAdminExerciseCommand(int IdExercise) : IRequest
    {
        
    }
}

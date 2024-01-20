using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteGym
{
    public record  DeleteGymCommand(int idGym) : IRequest
    {
        
    }
}

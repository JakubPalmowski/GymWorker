using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.User.DeleteInvitation
{
    public record DeleteInvitationCommand(int Id, int SecondId) : IRequest;
    
}

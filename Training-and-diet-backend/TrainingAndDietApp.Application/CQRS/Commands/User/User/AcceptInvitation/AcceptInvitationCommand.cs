using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.User.AcceptInvitation
{
    public record AcceptInvitationCommand(int IdPupil, int IdMentor) : IRequest;
    
}

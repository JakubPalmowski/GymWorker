using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Pupil.SendInvitation
{
    public record SendInvitationCommand(int IdPupil,int IdMentor) : IRequest;

}

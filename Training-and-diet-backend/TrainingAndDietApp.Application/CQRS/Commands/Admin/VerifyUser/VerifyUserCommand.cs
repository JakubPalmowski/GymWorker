using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyUser
{
    public class VerifyUserCommand : IRequest
    {
        public int IdRole { get; set; }
        public bool IsAccepted { get; set; }


    }
}

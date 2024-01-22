using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyUser
{
    public class VerifyUserInternalCommand : IRequest
    {
        public VerifyUserInternalCommand(int idUser, VerifyUserCommand verifyUserCommand)
        {
            IdUser = idUser;
            VerifyUserCommand = verifyUserCommand;
        }

        public int IdUser { get; set; }
        public VerifyUserCommand VerifyUserCommand { get; set; }
    }
}

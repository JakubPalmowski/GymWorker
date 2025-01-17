using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Dietician.UpdateDietician
{
    public class UpdateDieticianInternalCommand : IRequest
    {
        public UpdateDieticianInternalCommand(int idUser, UpdateDieticianCommand dieticianCommand)
        {
            IdUser = idUser;
            DieticianCommand = dieticianCommand;
        }


        public int IdUser { get; set; }
        public UpdateDieticianCommand DieticianCommand { get; set; }
    }
}

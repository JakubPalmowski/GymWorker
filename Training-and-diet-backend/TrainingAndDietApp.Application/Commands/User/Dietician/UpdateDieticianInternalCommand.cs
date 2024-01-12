using MediatR;

namespace TrainingAndDietApp.Application.Commands.User.Dietician
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

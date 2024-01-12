using MediatR;

namespace TrainingAndDietApp.Application.Commands.User.DieticianTrainer
{
    public class UpdateDieticianTrainerInternalCommand : IRequest
    {
        public UpdateDieticianTrainerInternalCommand(int idUser, UpdateDieticianTrainerCommand dieticianTrainerCommand)
        {
            IdUser = idUser;
            DieticianTrainerCommand = dieticianTrainerCommand;
        }
        
        
        public int IdUser { get; set; }
        public UpdateDieticianTrainerCommand DieticianTrainerCommand { get; set; }
    }
}

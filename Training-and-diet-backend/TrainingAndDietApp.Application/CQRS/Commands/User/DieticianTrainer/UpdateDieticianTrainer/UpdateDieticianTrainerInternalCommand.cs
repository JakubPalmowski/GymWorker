using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.DieticianTrainer.UpdateDieticianTrainer
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

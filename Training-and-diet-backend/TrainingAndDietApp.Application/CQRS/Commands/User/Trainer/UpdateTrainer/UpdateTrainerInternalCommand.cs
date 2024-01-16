using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Trainer.UpdateTrainer
{
    public class UpdateTrainerInternalCommand : IRequest
    {
        public UpdateTrainerInternalCommand(int idUser, UpdateTrainerCommand trainerCommand)
        {
            IdUser = idUser;
            TrainerCommand = trainerCommand;
        }


        public int IdUser { get; set; }
        public UpdateTrainerCommand TrainerCommand { get; set; }
    }
}

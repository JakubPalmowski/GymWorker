using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateGym
{
    public class UpdateGymInternalCommand : IRequest
    {
        public UpdateGymInternalCommand(int idGym, UpdateGymCommand gymCommand)
        {
            IdGym = idGym;
            GymCommand = gymCommand;
        }

        public int IdGym { get; set; }
        public UpdateGymCommand GymCommand { get; set; }


    }
}

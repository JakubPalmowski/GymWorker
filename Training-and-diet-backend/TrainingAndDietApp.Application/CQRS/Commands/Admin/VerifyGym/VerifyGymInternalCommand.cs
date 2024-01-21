using MediatR;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateGym;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyGym
{
    public class VerifyGymInternalCommand : IRequest
    {
       
        public VerifyGymInternalCommand(int idGym, UpdateGymCommand gymCommand)
        {
            IdGym = idGym;
            GymCommand = gymCommand;
        }

        public int IdGym { get; set; }
        public UpdateGymCommand GymCommand { get; set; }

    }
}

using MediatR;

namespace TrainingAndDietApp.Application.Commands.User.Pupil
{
    public class UpdatePupilInternalCommand : IRequest
    {
        public UpdatePupilInternalCommand(int idUser, UpdatePupilCommand pupilCommand)
        {
            IdUser = idUser;
            PupilCommand = pupilCommand;
        }
        public int IdUser { get; set; }
        public UpdatePupilCommand PupilCommand { get; set; }
    }
}

using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Pupil.UpdatePupil
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

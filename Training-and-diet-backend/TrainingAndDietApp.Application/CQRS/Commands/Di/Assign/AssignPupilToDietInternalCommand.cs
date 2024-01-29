using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Assign
{
    public record AssignPupilToDietInternalCommand(int IdDiet, int IdDietician, AssignPupilToDietCommand AssignPupilToDietCommand) : IRequest;
  
    public class AssignPupilToDietCommand
    {
        public int IdPupil { get; set; }
    }
}


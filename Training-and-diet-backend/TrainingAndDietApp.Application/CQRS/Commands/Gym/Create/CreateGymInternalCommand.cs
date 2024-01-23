using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Gym.Create
{
    public record CreateGymInternalCommand(int IdUser, CreateGymCommand GymCommand) : IRequest;
    public class CreateGymCommand
    {   
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

    }
}

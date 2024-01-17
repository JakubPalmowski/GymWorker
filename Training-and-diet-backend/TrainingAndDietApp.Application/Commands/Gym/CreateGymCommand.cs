using MediatR;

namespace TrainingAndDietApp.Application.Commands.Gym
{
    public class CreateGymCommand : IRequest
    {
        public string Name { get; set; }
        public int AddedBy { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

    }
}

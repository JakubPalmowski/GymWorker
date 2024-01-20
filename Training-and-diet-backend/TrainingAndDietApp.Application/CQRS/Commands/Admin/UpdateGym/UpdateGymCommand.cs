using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateGym
{
    public class UpdateGymCommand : IRequest
    {
        public string City { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }


    }
}

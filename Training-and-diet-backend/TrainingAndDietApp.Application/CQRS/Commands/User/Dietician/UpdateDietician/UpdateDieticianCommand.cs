using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Dietician.UpdateDietician
{
    public class UpdateDieticianCommand : IRequest
    {
        public UpdateDieticianCommand(string name, string lastName, string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Bio { get; set; }
        public decimal? DietPriceFrom { get; set; }
        public decimal? DietPriceTo { get; set; }
    }
}

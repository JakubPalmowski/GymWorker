using MediatR;
using TrainingAndDietApp.Application.Responses.Gym;

namespace TrainingAndDietApp.Application.Commands.User.DieticianTrainer
{
    public class UpdateDieticianTrainerCommand : IRequest
    {
         public UpdateDieticianTrainerCommand(string name, string lastName, string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            TrainerGyms = new List<ActiveGymResponse>();
        }
    
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Bio { get; set; }
        public decimal? TrainingPlanPriceFrom { get; set; }
        public decimal? TrainingPlanPriceTo { get; set; }
        public decimal? PersonalTrainingPriceFrom { get; set; }
        public decimal? PersonalTrainingPriceTo { get; set; }
        public decimal? DietPriceFrom { get; set; }
        public decimal? DietPriceTo { get; set; }
        public List<ActiveGymResponse> TrainerGyms { get; set;}
    }
}

using Training_and_diet_backend.DTOs.Opinion;
using TrainingAndDietApp.Common.DTOs.Gym;

namespace TrainingAndDietApp.Common.DTOs.User
{
    public class MentorWithOpinionDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int OpinionNumber { get; set; }
        public decimal TotalRate { get; set; }
        public decimal? TrainingPlanPriceFrom { get; set; }
        public decimal? TrainingPlanPriceTo { get; set; }
        public decimal? PersonalTrainingPriceFrom { get; set; }
        public decimal? PersonalTrainingPriceTo { get; set; }
        public decimal? DietPriceFrom { get; set; }
        public decimal? DietPriceTo { get; set; }
        public List<OpinionDto> Opinions { get; set; }
        public List<GymDto> TrainerGyms {get; set; }


    }

}

using Training_and_diet_backend.DTOs.Gym;
using Training_and_diet_backend.DTOs.Opinion;

namespace Training_and_diet_backend.DTOs.User
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
        public int Opinion_number { get; set; }
        public decimal TotalRate { get; set; }
        public decimal? Training_plan_price_from { get; set; }
        public decimal? Training_plan_price_to { get; set; }
        public decimal? Personal_training_price_from { get; set; }
        public decimal? Personal_training_price_to { get; set; }
        public decimal? Diet_price_from { get; set; }
        public decimal? Diet_price_to { get; set; }
        public List<OpinionDto> Opinions { get; set; }
        public List<GymDto> TrainerGyms {get; set; }


    }

}

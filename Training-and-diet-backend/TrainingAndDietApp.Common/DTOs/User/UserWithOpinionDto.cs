using Training_and_diet_backend.DTOs.Opinion;

namespace TrainingAndDietApp.Common.DTOs.User
{
    public class UserWithOpinionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public int Opinion_number { get; set; }
        public decimal TotalRate { get; set; }
        public List<OpinionDto> Opinions { get; set; }


    }

}

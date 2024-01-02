namespace TrainingAndDietApp.Common.DTOs.User
{
    public class MentorDto
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public int OpinionNumber { get; set; }
        public decimal Rate { get; set; }
        public string RoleName { get; set; }
        public decimal? TrainingPlanPriceFrom { get; set; }
        public decimal? TrainingPlanPriceTo { get; set; }
        public decimal? PersonalTrainingPriceFrom { get; set; }
        public decimal? PersonalTrainingPriceTo { get; set; }
        public decimal? DietPriceFrom { get; set; }
        public decimal? DietPriceTo { get; set; }

    }

}

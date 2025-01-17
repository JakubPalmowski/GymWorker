namespace TrainingAndDietApp.Application.CQRS.Responses.Trainer
{
    public class TrainerPersonalInfoResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public bool EmailValidated { get; set; }
        public string? Bio { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal? TrainingPlanPriceFrom { get; set; }
        public decimal? TrainingPlanPriceTo { get; set; }
        public decimal? PersonalTrainingPriceFrom { get; set; }
        public decimal? PersonalTrainingPriceTo { get; set; }
        public string? ImageUri {get; set;}
        public bool IsAccepted { get; set; }
    }
}

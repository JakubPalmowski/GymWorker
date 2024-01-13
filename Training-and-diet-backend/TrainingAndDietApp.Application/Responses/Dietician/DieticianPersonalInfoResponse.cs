namespace TrainingAndDietApp.Application.Responses.Dietician
{
    public class DieticianPersonalInfoResponse
    {
        public string Name { get; set; }
            public string LastName { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public bool EmailValidated { get; set; }
            public string? Bio { get; set; }
            public string? PhoneNumber { get; set; }
            public decimal? DietPriceFrom { get; set; }
            public decimal? DietPriceTo { get; set; }
           
    }
}

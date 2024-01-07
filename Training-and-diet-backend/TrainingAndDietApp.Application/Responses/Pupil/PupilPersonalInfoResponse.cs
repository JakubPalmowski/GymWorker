namespace TrainingAndDietApp.Application.Responses.Pupil
{
    public class PupilPersonalInfoResponse
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public bool EmailValidated { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal? Weight { get; set; }
      
    public decimal? Height { get; set; }
    public int? Age { get; set; }
    
    public string? Sex { get; set; }
      
    public string? Bio { get; set; }
    }
}

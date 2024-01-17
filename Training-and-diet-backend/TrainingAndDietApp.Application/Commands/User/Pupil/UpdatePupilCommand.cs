using MediatR;

namespace TrainingAndDietApp.Application.Commands.User.Pupil
{
    public class UpdatePupilCommand : IRequest
    {

        public UpdatePupilCommand(string name, string lastName, string email )
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public DateTime? DateOfBirth { get; set; } 
    public string? Sex { get; set; } 
    public string? Bio { get; set; } 


    }
}

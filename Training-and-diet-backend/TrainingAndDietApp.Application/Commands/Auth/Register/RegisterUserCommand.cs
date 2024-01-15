using MediatR;

namespace TrainingAndDietApp.Application.Commands.Auth.Register;

public record RegisterUserCommand (string Name, string LastName, string Email, string Password, string PhoneNumber, int RoleId) : IRequest<RegisterUserResponse>;

public class RegisterUserResponse
{
    public RegisterUserResponse(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}


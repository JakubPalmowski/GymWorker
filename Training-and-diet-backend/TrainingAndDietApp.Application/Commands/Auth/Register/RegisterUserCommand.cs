using MediatR;
using TrainingAndDietApp.Application.Responses.Auth;

namespace TrainingAndDietApp.Application.Commands.Auth.Register;

public record RegisterUserCommand (string Name, string LastName, string Email, string Password, string PhoneNumber, int RoleId) : IRequest<TokenResponse>;




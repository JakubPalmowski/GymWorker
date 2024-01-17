using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Auth;

namespace TrainingAndDietApp.Application.CQRS.Commands.Auth.Register;

public record RegisterUserCommand(string Name, string LastName, string Email, string Password, string PhoneNumber, int RoleId) : IRequest<TokenResponse>;




using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Auth;

namespace TrainingAndDietApp.Application.CQRS.Commands.Auth.Login;

public record LoginCommand(string Email, string Password) : IRequest<TokenResponse>;




using MediatR;
using TrainingAndDietApp.Application.Responses.Auth;

namespace TrainingAndDietApp.Application.Commands.Auth.Login;

public record LoginCommand(string Email, string Password) : IRequest<TokenResponse>;




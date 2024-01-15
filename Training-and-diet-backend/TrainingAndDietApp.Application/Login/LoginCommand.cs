using MediatR;

namespace TrainingAndDietApp.Application.Login;

public record LoginCommand (string Email, string Password) : IRequest<string>;



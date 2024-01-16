using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Auth;

namespace TrainingAndDietApp.Application.CQRS.Commands.Auth.Refresh;

public record RefreshTokenCommand(string AccessToken, string RefreshToken) : IRequest<TokenResponse>;

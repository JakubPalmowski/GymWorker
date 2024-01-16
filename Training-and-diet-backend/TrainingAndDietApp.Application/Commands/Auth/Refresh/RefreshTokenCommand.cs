using MediatR;
using TrainingAndDietApp.Application.Responses.Auth;

namespace TrainingAndDietApp.Application.Commands.Auth.Refresh;

public record RefreshTokenCommand(string AccessToken, string RefreshToken) : IRequest<TokenResponse>;

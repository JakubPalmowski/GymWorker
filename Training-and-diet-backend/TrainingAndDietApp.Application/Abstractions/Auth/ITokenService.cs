using System.Security.Claims;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.Abstractions.Auth;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    Tuple<string, DateTime> GenerateRefreshToken();
    int? VerifyAccessToken (string accessToken, bool validateLifetime = true);
    
}
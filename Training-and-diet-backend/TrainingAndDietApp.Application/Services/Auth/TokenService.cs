using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TrainingAndDietApp.Application.Abstractions.Auth;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    //refactor issuer audience i secret
    public string GenerateAccessToken(User user)
    {
        var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
            new Claim(ClaimTypes.Role, user.Role.Name)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PPZ2VwlQAkgwfLwhskyuQPEhW13uFT2H8Ql0A2TsIBMEy8iYRc"));
        var jwt = new JwtSecurityToken( issuer: "https://localhost:5001",
            audience: "https://localhost:5001",
            claims: userClaims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public Tuple<string, DateTime> GenerateRefreshToken()
    {
        var refreshToken = Guid.NewGuid().ToString();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(1);
        return new Tuple<string, DateTime>(refreshToken, refreshTokenExpiration);
    }

    public int VerifyAccessToken(string accessToken, bool validateExpiration = true)
    {
        throw new NotImplementedException();
    }
}
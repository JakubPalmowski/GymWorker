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
            new Claim(ClaimTypes.Role, user.Role.Id.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
        var jwt = new JwtSecurityToken( issuer: "https://localhost:5001",
            audience: "https://localhost:5001",
            claims: userClaims,
            expires: DateTime.UtcNow.AddHours(1),
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
    //refactor secret key
    public int? VerifyAccessToken(string accessToken, bool validateLifetime = true)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
        try
        {
            tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = "https://localhost:5001",
                ValidateAudience = true,
                ValidAudience = "https://localhost:5001",
                ValidateLifetime = validateLifetime
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken) validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return userId;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
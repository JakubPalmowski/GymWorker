namespace TrainingAndDietApp.Application.Responses.Auth;

public class TokenResponse
{
    public TokenResponse(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
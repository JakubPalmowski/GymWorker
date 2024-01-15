using TrainingAndDietApp.Application.Abstractions.Auth;

namespace TrainingAndDietApp.Application.Services.Auth;

public class PasswordService : IPasswordService
{


    public string HashPassword(string plainPassword)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainPassword);
    }

    public bool VerifyPassword(string plainPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }
}
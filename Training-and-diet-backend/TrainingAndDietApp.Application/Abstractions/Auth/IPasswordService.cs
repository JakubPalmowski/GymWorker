namespace TrainingAndDietApp.Application.Abstractions.Auth;

public interface IPasswordService
{
    string HashPassword(string plainPassword);
    bool VerifyPassword(string plainPassword, string hashedPassword);

}
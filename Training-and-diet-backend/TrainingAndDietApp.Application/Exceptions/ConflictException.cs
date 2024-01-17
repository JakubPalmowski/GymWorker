using Microsoft.IdentityModel.Tokens;

namespace TrainingAndDietApp.Application.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
    
}
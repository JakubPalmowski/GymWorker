using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Auth.Register;

namespace TrainingAndDietApp.Application.CQRS.Validators.Create.Auth;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        
            
    }
}
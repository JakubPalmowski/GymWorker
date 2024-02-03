using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Auth.Register;

namespace TrainingAndDietApp.Application.CQRS.Validators.Create.Auth;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Email )
            .NotEmpty().WithMessage("Email jest wymagany.")
            .EmailAddress().WithMessage("Niepoprawny format adresu email.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Hasło jest wymagane.")
            .Matches("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}");

        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Imię jest wymagane.")
            .MinimumLength(2).WithMessage("Imię musi zawierać minimum 2 znaki.")
            .MaximumLength(50).WithMessage("Imię może zawierać maksymalnie 50 znaków.");

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("Nazwisko jest wymagane.")
            .MinimumLength(2).WithMessage("Nazwisko musi zawierać minimum 2 znaki.")
            .MaximumLength(50).WithMessage("Nazwisko może zawierać maksymalnie 50 znaków.");

        RuleFor(u => u.RoleId)
            .NotEmpty().WithMessage("Rola jest wymagana.");

    }
}
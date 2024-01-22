using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyUser;


namespace TrainingAndDietApp.Application.CQRS.Validators.Update.User
{
    public class VerifyUserCommandValidator : AbstractValidator<VerifyUserCommand>
    {
        public VerifyUserCommandValidator()
        {
            RuleFor(command => command.IdRole)
                .NotEmpty().WithMessage("Rola użytkownika jest wymagane.")
                .Must(idRole => idRole == 3 || idRole == 4 || idRole == 5)
                .WithMessage("Wartość roli użytkownika musi być równa 3, 4 lub 5.");

            RuleFor(command => command.IsAccepted)
                .NotNull().WithMessage("Status konta jest wymagany.");
        }
    }
}

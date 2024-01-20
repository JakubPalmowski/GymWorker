using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateGym;

namespace TrainingAndDietApp.Application.CQRS.Validators.Update.Gym
{
    public class UpdateGymCommandValidator : AbstractValidator<UpdateGymCommand>
    {
        public UpdateGymCommandValidator()
        {
            RuleFor(gym => gym.Name)
            .NotEmpty().WithMessage("Nazwa siłowni jest wymagana.")
            .MaximumLength(100).WithMessage("Nazwa siłowni może zawierać maksymalnie 100 znaków.");
            

            RuleFor(gym => gym.City)
                .NotEmpty().WithMessage("Nazwa miasta jest wymagana.")
                .MaximumLength(85).WithMessage("Nazwa miasta może zawierać maksymalnie 85 znaków.");

            RuleFor(gym => gym.Street)
                .NotEmpty().WithMessage("Nazwa ulicy jest wymagana.")
                .MaximumLength(120).WithMessage("Nazwa ulicy może zawierać maksymalnie 120 znaków.");

            RuleFor(gym => gym.PostalCode)
                .NotEmpty().WithMessage("Kod pocztowy jest wymagany.")
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Nieprawidłowy format kodu pocztowego. Poprawny format to XX-XXX.");
            
        }
    }
}

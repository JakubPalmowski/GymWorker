using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.User.Dietician.UpdateDietician;

namespace TrainingAndDietApp.Application.CQRS.Validators.Update.Dietician
{
    public class UpdateDieticianCommandValidator : AbstractValidator<UpdateDieticianCommand>
    {
        public UpdateDieticianCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Imię jest wymagane.")
                .MaximumLength(50).WithMessage("Imię nie może przekraczać 50 znaków.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Nazwisko jest wymagane.")
                .MaximumLength(50).WithMessage("Nazwisko nie może przekraczać 50 znaków.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email jest wymagany.")
                .EmailAddress().WithMessage("Nieprawidłowy adres email.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+48\s?(\d{3}[ ]?){3}$|^(\d{3}[ ]?){3}$")
                .WithMessage("Numer telefonu musi być poprawnym polskim numerem telefonu z prefiksem '+48' lub bez niego.");

            RuleFor(x => x.Bio)
                .MaximumLength(1500).WithMessage("Opis nie może przekraczać 1500 znaków.");



            RuleFor(x => x.DietPriceFrom)
                .InclusiveBetween(0.00m, 99999.99m).When(x => x.DietPriceFrom.HasValue)
                .WithMessage("Cena musi być w zakresie od 0.00 do 99999.99");

            RuleFor(x => x.DietPriceTo)
                .InclusiveBetween(0.00m, 99999.99m).When(x => x.DietPriceTo.HasValue)
                .WithMessage("Cena musi być w zakresie od 0.00 do 99999.99");

            RuleFor(x => x)
                .Must(x => !x.DietPriceFrom.HasValue || !x.DietPriceTo.HasValue || x.DietPriceTo >= x.DietPriceFrom)
                .WithMessage("Cena maksymalna za dietę musi być większa lub równa cenie minimalnej");

            RuleFor(x => x)
                .Must(x => x.DietPriceFrom.HasValue && x.DietPriceTo.HasValue || !x.DietPriceFrom.HasValue && !x.DietPriceTo.HasValue)
                .WithMessage("Obie ceny za dietę muszą być podane lub obie muszą być puste");
        }
    }
}

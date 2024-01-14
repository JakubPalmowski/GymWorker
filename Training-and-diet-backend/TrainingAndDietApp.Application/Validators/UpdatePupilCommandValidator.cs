using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TrainingAndDietApp.Application.Commands.User.Pupil;

namespace TrainingAndDietApp.Application.Validators
{
    public class UpdatePupilCommandValidator : AbstractValidator<UpdatePupilCommand>
    {
        public UpdatePupilCommandValidator()
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

            RuleFor(x => x.Weight)
                .InclusiveBetween(0.01m, 300.00m)
                .WithMessage("Waga musi być w przedziale od 0.01 do 300.00");

            RuleFor(x => x.Height)
                .InclusiveBetween(0.01m, 250.00m)
                .WithMessage("Wzrost musi być w przedziale od 0.01 do 250.00");

            RuleFor(x => x.DateOfBirth)
                .Must(BeAValidDate).WithMessage("Data urodzenia musi być prawidłową datą")
                .Must(date => date == null || date <= DateTime.Now)
                .WithMessage("Data urodzenia nie może być w przyszłości");

            RuleFor(x => x.Sex)
                .Must(s => string.IsNullOrEmpty(s) || s == "Mężczyzna" || s == "Kobieta")
                .WithMessage("Płeć musi być 'Mężczyzna', 'Kobieta' lub pusta");
        }

        private bool BeAValidDate(DateTime? date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

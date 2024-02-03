using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Di.Create;
using TrainingAndDietApp.Application.CQRS.Commands.Di.Update;

namespace TrainingAndDietApp.Application.CQRS.Validators.Update.Diet;

public class UpdateDietCommandValidator : AbstractValidator<UpdateDietCommand>
{
    public UpdateDietCommandValidator()
    {
        // Walidacja dla Name: wymagane, minimum 3 znaki, maksymalnie 50 znaków
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nazwa jest wymagana.")
            .Length(3, 50).WithMessage("Nazwa musi mieć od 3 do 50 znaków.");

        // Walidacja dla CustomName: maksymalnie 50 znaków
        RuleFor(x => x.CustomName)
            .MaximumLength(50).WithMessage("Nazwa własna nie może przekraczać 50 znaków.");

        // Walidacja dla Type: minimum 3 znaki, maksymalnie 50 znaków
        RuleFor(x => x.Type)
            .Length(3, 50).WithMessage("Typ musi mieć od 3 do 50 znaków.");


        // Walidacja dla NumberOfWeeks: wymagane, minimum 1, maksymalnie 50
        RuleFor(x => x.NumberOfWeeks)
            .NotNull().WithMessage("Całkowita liczba kalorii jest wymagana.")
            .NotEmpty().WithMessage("Liczba tygodni jest wymagana.")
            .InclusiveBetween(1, 50).WithMessage("Liczba tygodni musi być między 1 a 50.");

        // Walidacja dla TotalKcal: wymagane, minimum 100, maksymalnie 10 000
        RuleFor(x => x.TotalKcal)
            .NotNull().WithMessage("Całkowita liczba kalorii jest wymagana.")
            .NotEmpty().WithMessage("Całkowita liczba kalorii jest wymagana.")
            .InclusiveBetween(100, 10000).WithMessage("Całkowita liczba kalorii musi być między 100 a 10 000.");
    }
}
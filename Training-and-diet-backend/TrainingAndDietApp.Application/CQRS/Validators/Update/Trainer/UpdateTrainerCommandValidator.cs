﻿using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.User.Trainer.UpdateTrainer;

namespace TrainingAndDietApp.Application.CQRS.Validators.Update.Trainer
{
    public class UpdateTrainerCommandValidator : AbstractValidator<UpdateTrainerCommand>
    {
        public UpdateTrainerCommandValidator()
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
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Numer telefonu musi być poprawnym polskim numerem telefonu z prefiksem '+48' lub bez niego.");


            RuleFor(x => x.Bio)
                .MaximumLength(1500).WithMessage("Opis nie może przekraczać 1500 znaków.");


            RuleFor(x => x.TrainingPlanPriceFrom)
                .InclusiveBetween(0.00m, 99999.99m).When(x => x.TrainingPlanPriceFrom.HasValue)
                .WithMessage("Cena musi być w zakresie od 0.00 do 99999.99");

            RuleFor(x => x.TrainingPlanPriceTo)
                .InclusiveBetween(0.00m, 99999.99m).When(x => x.TrainingPlanPriceTo.HasValue)
                .WithMessage("Cena musi być w zakresie od 0.00 do 99999.99");

            RuleFor(x => x)
                .Must(x => !x.TrainingPlanPriceFrom.HasValue || !x.TrainingPlanPriceTo.HasValue || x.TrainingPlanPriceTo >= x.TrainingPlanPriceFrom)
                .WithMessage("Cena maksymalna dla planu treningowego musi być większa lub równa cenie minimalnej");

            RuleFor(x => x)
                .Must(x => x.TrainingPlanPriceFrom.HasValue && x.TrainingPlanPriceTo.HasValue || !x.TrainingPlanPriceFrom.HasValue && !x.TrainingPlanPriceTo.HasValue)
                .WithMessage("Obie ceny dla planu treningowego muszą być podane lub obie muszą być puste");


            RuleFor(x => x.PersonalTrainingPriceFrom)
                .InclusiveBetween(0.00m, 99999.99m).When(x => x.PersonalTrainingPriceFrom.HasValue)
                .WithMessage("Cena musi być w zakresie od 0.00 do 99999.99");

            RuleFor(x => x.PersonalTrainingPriceTo)
                .InclusiveBetween(0.00m, 99999.99m).When(x => x.PersonalTrainingPriceTo.HasValue)
                .WithMessage("Cena musi być w zakresie od 0.00 do 99999.99");

            RuleFor(x => x)
                .Must(x => !x.PersonalTrainingPriceFrom.HasValue || !x.PersonalTrainingPriceTo.HasValue || x.PersonalTrainingPriceTo >= x.PersonalTrainingPriceFrom)
                .WithMessage("Cena maksymalna za trening personalny musi być większa lub równa cenie minimalnej");

            RuleFor(x => x)
                .Must(x => x.PersonalTrainingPriceFrom.HasValue && x.PersonalTrainingPriceTo.HasValue || !x.PersonalTrainingPriceFrom.HasValue && !x.PersonalTrainingPriceTo.HasValue)
                .WithMessage("Obie ceny za trening personalny muszą być podane lub obie muszą być puste");
        }

    }



}
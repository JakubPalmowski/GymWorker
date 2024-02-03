using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.UpdateTrainingPlan;

namespace TrainingAndDietApp.Application.CQRS.Validators.Update.TrainingPlan;

public class UpdateTrainingPlanCommandValidator : AbstractValidator<UpdateTrainingPlanCommand>
{
    public UpdateTrainingPlanCommandValidator ()   
    {
        RuleFor(trainingPlan => trainingPlan.Name)
            .NotEmpty().WithMessage("Nazwa planu treningowego jest wymagana.")
            .MinimumLength(3).WithMessage("Nazwa planu treningowego musi zawierać minimum 3 znaki.")
            .MaximumLength(50).WithMessage("Nazwa planu treningowego może zawierać maksymalnie 50 znaków.");

        RuleFor(trainingPlan => trainingPlan.CustomName)
            .MaximumLength(50).WithMessage("Własny opis planu treningowego może zawierać maksymalnie 50 znaków.");

        RuleFor(trainingPlan => trainingPlan.Type)
            .NotEmpty().WithMessage("Typ planu treningowego jest wymagany.")
            .MinimumLength(3).WithMessage("Typ planu treningowego musi zawierać minimum 3 znaki.")
            .MaximumLength(50).WithMessage("Typ planu treningowego musi zawierać maksymalnie 50 znaków.");

        RuleFor(trainingPlan => trainingPlan.NumberOfWeeks)
            .NotEmpty().WithMessage("Liczba tygodni planu treningowego jest wymagana")
            .GreaterThan(0).WithMessage("Liczba tygodni planu treningowego musi być większa od 0.")
            .LessThan(50).WithMessage("Liczba tygodni planu treningowego nie może być większa niż 50.");

    }
}
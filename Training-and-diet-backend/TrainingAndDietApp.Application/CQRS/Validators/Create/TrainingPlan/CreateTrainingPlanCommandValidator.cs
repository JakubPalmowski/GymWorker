using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.CreateTrainingPlan;

namespace TrainingAndDietApp.Application.CQRS.Validators.Create.TrainingPlan;

public class CreateTrainingPlanCommandValidator : AbstractValidator<CreateTrainingPlanCommand>
{
    public CreateTrainingPlanCommandValidator() 
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

        RuleFor(trainingPlan => trainingPlan.StartDate)
            .NotEmpty().WithMessage("Data planu treningowego jest wymagana.")
            .LessThan(trainingPlan => DateTime.Now).WithMessage("Data rozpoczęcia planu treningowego nie może być późniejsza niż dziś.");
            
        RuleFor(trainingPlan => trainingPlan.NumberOfWeeks)
            .NotEmpty().WithMessage("Liczba tygodni planu treningowego jest wymagana")
            .GreaterThan(0).WithMessage("Liczba tygodni planu treningowego musi być większa od 0.")
            .LessThan(50).WithMessage("Liczba tygodni planu treningowego nie może być większa niż 50.");

    }
}
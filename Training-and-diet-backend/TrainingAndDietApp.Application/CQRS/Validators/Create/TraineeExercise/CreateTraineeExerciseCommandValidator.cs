using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.CreateTraineeExercise;

namespace TrainingAndDietApp.Application.CQRS.Validators.Create.TraineeExercise;

public class CreateTraineeExerciseCommandValidator : AbstractValidator<CreateTraineeExerciseCommand>
{
    public CreateTraineeExerciseCommandValidator()
    {
        RuleFor(traineeExercise => traineeExercise.SeriesNumber)
            .NotEmpty().WithMessage("Ilość serii jest wymagana.")
            .GreaterThanOrEqualTo(0).WithMessage("Ilość serii musi być większa od 0.")
            .LessThan(6).WithMessage("Ilość serii nie może być większa niż 6.");

        RuleFor(traineeExercise => traineeExercise.Comments)
            .MaximumLength(200).WithMessage("Komentarz do ćwiczenia może zawierać maksymalnie 200 znaków.");

        RuleFor(traineeExercise => traineeExercise.DayOfWeek)
            .NotEmpty().WithMessage("Dzień tygodnia planu treningowego jest wymagany.")
            .IsInEnum().WithMessage("Dzień tygodnia planu treningowego jest nieprawidłowy.");
        
        RuleFor(traineeExercise => traineeExercise.IdExercise)
            .NotEmpty().WithMessage("Id ćwiczenia jest wymagane.")
            .GreaterThan(0).WithMessage("Id ćwiczenia musi być większe od 0.");

        RuleFor(traineeExercise => traineeExercise.IdTrainingPlan)
            .NotEmpty().WithMessage("Id planu treningowego jest wymagane.")
            .GreaterThan(0).WithMessage("Id planu treningowego musi być większe od 0.");
    }
}
using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.UpdateTraineeExercise;

namespace TrainingAndDietApp.Application.CQRS.Validators.Update.TraineeExercise;

public class UpdateTraineeExerciseCommandValidator : AbstractValidator<UpdateTraineeExerciseCommand>
{
    public UpdateTraineeExerciseCommandValidator()
    {
        RuleFor(traineeExercise => traineeExercise.SeriesNumber)
            .GreaterThanOrEqualTo(0).WithMessage("Ilość serii musi być większa od 0.")
            .LessThan(6).WithMessage("Ilość serii nie może być większa niż 6.");

        RuleFor(traineeExercise => traineeExercise.Comments)
            .MaximumLength(200).WithMessage("Komentarz do ćwiczenia może zawierać maksymalnie 200 znaków.");

        RuleFor(traineeExercise => traineeExercise.DayOfWeek)
            .NotEmpty().WithMessage("Dzień tygodnia planu treningowego jest wymagany.")
            .InclusiveBetween(1, 7).WithMessage("Dzień tygodnia musi być w zakresie od 1 do 7.");

    }
}
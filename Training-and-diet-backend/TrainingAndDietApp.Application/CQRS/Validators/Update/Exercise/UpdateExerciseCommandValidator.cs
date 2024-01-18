using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.UpdateExercise;

namespace TrainingAndDietApp.Application.CQRS.Validators.Update.Exercise;

public class UpdateExerciseCommandValidator : AbstractValidator<UpdateExerciseCommand>
{
    public UpdateExerciseCommandValidator(){
        RuleFor(exercise => exercise.Name)
            .NotEmpty().WithMessage("Nazwa ćwiczenia jest wymagana.")
            .MinimumLength(3).WithMessage("Nazwa ćwiczenia musi zawierać minimum 3 znaki.")
            .MaximumLength(50).WithMessage("Nazwa ćwiczenia może zawierać maksymalnie 50 znaków.");

        RuleFor(exercise => exercise.Details)
            .NotEmpty().WithMessage("Opis ćwiczenia jest wymagany.")
            .MinimumLength(3).WithMessage("Opis ćwiczenia musi zawierać minimum 3 znaki.")
            .MaximumLength(200).WithMessage("Opis ćwiczenia może zawierać maksymalnie 200 znaków.");

        RuleFor(exercise => exercise.ExerciseSteps)
            .NotEmpty().WithMessage("Kroki ćwiczenia są wymagane.")
            .MinimumLength(3).WithMessage("Kroki ćwiczenia muszą zawierać minimum 3 znaki.")
            .MaximumLength(300).WithMessage("Kroki ćwiczenia mogą zawierać maksymalnie 300 znaków.");

    }

}
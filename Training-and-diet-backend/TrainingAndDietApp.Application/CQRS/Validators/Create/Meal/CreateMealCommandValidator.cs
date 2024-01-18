using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Meal.CreateMeal;

namespace TrainingAndDietApp.Application.CQRS.Validators.Create.Meal;

public class CreateMealCommandValidator : AbstractValidator<CreateMealCommand>
{
    public CreateMealCommandValidator()
    {
        RuleFor(meal => meal.IdDietician)
            .NotEmpty().WithMessage("Pole jest wymagane")
            .GreaterThan(0).WithMessage("Id dietetyka musi być większe od 0.");

        RuleFor(meal => meal.Name)
            .NotEmpty().WithMessage("Nazwa dania jest wymagana")
            .MinimumLength(3).WithMessage("Nazwa dania musi zawierać minimum 3 znaki.")
            .MaximumLength(50).WithMessage("Nazwa dania może zawierać maksymalnie 50 znaków.");

        RuleFor(meal => meal.Ingredients)
            .NotEmpty().WithMessage("Składniki są wymagane")
            .MinimumLength(3).WithMessage("Składniki dania muszą zawierać minimum 3 znaki.")
            .MaximumLength(200).WithMessage("Składniki dania mogą zawierać maksymalnie 200 znaków.");

        RuleFor(meal => meal.PrepareSteps)
            .MaximumLength(300).WithMessage("Sposób przygotowania dania może zawierać maksymalnie 200 znaków.");
    }
}
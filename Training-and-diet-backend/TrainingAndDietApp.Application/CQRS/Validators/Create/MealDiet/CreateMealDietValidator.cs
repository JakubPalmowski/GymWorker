using System.Text.RegularExpressions;
using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Create;

namespace TrainingAndDietApp.Application.CQRS.Validators.Create.DietMeal
{
    public class CreateMealDietValidator : AbstractValidator<CreateMealDietCommand>
    {
        public CreateMealDietValidator()
        {
            RuleFor(command => command.Comments)
                .MaximumLength(300)
                .When(command => !string.IsNullOrEmpty(command.Comments))
                .WithMessage("Komentarze nie mogą być dłuższe niż 300 znaków.");

            RuleFor(command => command.DayOfWeek)
                .InclusiveBetween(1, 7)
                .WithMessage("Dzień tygodnia musi być w zakresie od 1 do 7.");

            RuleFor(command => command.HourOfMeal)
                .NotEmpty()
                .WithMessage("Godzina posiłku jest wymagana.")
                .Matches(new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"))
                .WithMessage("Godzina posiłku musi być w formacie HH:mm (np. 15:22, 6:44).");

            RuleFor(command => command.IdMeal)
                .NotEmpty()
                .WithMessage("IdMeal jest wymagane.");

            RuleFor(command => command.IdDiet)
                .NotEmpty()
                .WithMessage("IdDiet jest wymagane.");
        }
    }
}

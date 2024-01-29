using System.Text.RegularExpressions;
using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Update;


namespace TrainingAndDietApp.Application.CQRS.Validators.Update.MealDiet
{
    public class UpdateMealDietCommandValidator : AbstractValidator<UpdateMealDietCommand>
    {
        public UpdateMealDietCommandValidator()
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

        }
    }
}

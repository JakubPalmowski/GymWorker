using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Opinion;
using TrainingAndDietApp.Application.CQRS.Commands.Opinion.CreateOpinion;

namespace TrainingAndDietApp.Application.CQRS.Validators.Opinion
{
    public class CreateOpinionCommandValidator : AbstractValidator<CreateOpinionCommand>
    {
        public CreateOpinionCommandValidator()
        {
            RuleFor(command => command.IdMentor)
                .NotEmpty().WithMessage("Id mentora jest wymagane.");

            RuleFor(command => command.Content)
                .NotEmpty().WithMessage("Treść jest wymagana.")
                .MaximumLength(1000).WithMessage("Treść nie może być dłuższa niż 1000 znaków.");

            RuleFor(command => command.Rate)
                .NotEmpty().WithMessage("Ocena jest wymagana.")
                .Must(BeAValidRate).WithMessage("Ocena musi być równa 1.0, 2.0, 3.0, 4.0, lub 5.0.");
        }

        private bool BeAValidRate(decimal rate)
        {
            return rate == 1.0m || rate == 2.0m || rate == 3.0m || rate == 4.0m || rate == 5.0m;
        }
    }
}

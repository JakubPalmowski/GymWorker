using System.Data;
using FluentValidation;
using TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate;

namespace TrainingAndDietApp.Application.CQRS.Validators.Create.Certificate
{
    public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
    {
        public CreateCertificateCommandValidator()
        {
            RuleFor(c=>c.Description)
                .NotEmpty().WithMessage("Opis certyfikatu jest wymagany.")
                .MinimumLength(3).WithMessage("Opis certyfikatu musi zawierać minimum 3 znaki.")
                .MaximumLength(200).WithMessage("Opis certyfikatu może zawierać maksymalnie 200 znaków.");
        }
    }
}

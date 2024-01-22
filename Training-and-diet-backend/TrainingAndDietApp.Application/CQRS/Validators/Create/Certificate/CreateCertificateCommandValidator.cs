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

        
             RuleFor(c => c.PdfFile)
                .NotNull().WithMessage("Plik certyfikatu jest wymagany.");

            RuleFor(c => c.PdfFile)
                .Must(file => file != null && file.ContentType == "application/pdf")
                .When(c => c.PdfFile != null)
                .WithMessage("Plik certyfikatu musi być w formacie PDF.");

            RuleFor(c => c.PdfFile)
                .Must(file => file != null && file.Length < 1048576)
                .When(c => c.PdfFile != null)
                .WithMessage("Plik certyfikatu musi być mniejszy niż 1MB.");
        }
    }
}

using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyCertificate
{
    public record VerifyCertificateCommand(int IdCertificate) : IRequest
    {
    }
}

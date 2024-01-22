using MediatR;
using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.CQRS.Responses.Certificate;

namespace TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate
{
    public record CreateCertificateInternalCommand(int IdMentor, CreateCertificateCommand CertificateCommand) : IRequest<CreateCertificateResponse>
    {
    }
}

using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteCertificate
{
    public record DeleteCertificateCommand(int IdCertificate) : IRequest
    {
        
    }
}

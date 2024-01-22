using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetCertificateInfoForVerification
{
    public record GetCertificateInfoForVerificationQuery(int IdCertificate) : IRequest<CertificateVerificationResponse>
    {


    }

}

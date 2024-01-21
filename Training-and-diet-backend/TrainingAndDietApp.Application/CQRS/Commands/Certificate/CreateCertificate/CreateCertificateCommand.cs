using MediatR;
using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.CQRS.Responses.Certificate;

namespace TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate
{
    public record CreateCertificateCommand 
    {
        public string Description { get; set; }

    }
}

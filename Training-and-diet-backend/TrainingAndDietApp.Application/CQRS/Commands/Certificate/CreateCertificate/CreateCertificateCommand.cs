using MediatR;
using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.CQRS.Responses.Certificate;

namespace TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate
{
    public class CreateCertificateCommand 
    {
        public CreateCertificateCommand()
        {
            
        }
        public string Description { get; set; }
        public IFormFile PdfFile { get; set; }

    }
}

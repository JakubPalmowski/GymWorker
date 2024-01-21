using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.Certificate.GetUserCertificates
{
    public record GetUserCertificatesQuery(int IdMentor) : IRequest<List<GetUserCertificatesQuery>>
    {
        public DateTime AddedDate { get; set; }
        public bool IsAccepted { get; set; }
    }
}

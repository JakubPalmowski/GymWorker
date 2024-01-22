using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserCertificatesById
{
    public record GetUserCertificatesByIdQuery(int IdMentor) : IRequest<List<GetUserCertificatesByIdQuery>>{
        
        public int IdCertificate { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsAccepted { get; set; }

}

  
}

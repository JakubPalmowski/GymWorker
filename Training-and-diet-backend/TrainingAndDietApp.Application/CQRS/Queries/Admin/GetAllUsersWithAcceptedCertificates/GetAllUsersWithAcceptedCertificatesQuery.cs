using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllUsersWithAcceptedCertificates
{
    public class GetAllUsersWithAcceptedCertificatesQuery : IRequest<List<GetAllUsersWithCertificatesResponse>>
    {
        
    }
}

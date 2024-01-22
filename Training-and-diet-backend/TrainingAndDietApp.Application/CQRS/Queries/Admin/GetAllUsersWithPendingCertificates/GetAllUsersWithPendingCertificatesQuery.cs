using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllUsersWithPendingCertificates
{
    public class GetAllUsersWithPendingCertificatesQuery : IRequest<List<GetAllUsersWithCertificatesResponse>>
    {
        
    }
}

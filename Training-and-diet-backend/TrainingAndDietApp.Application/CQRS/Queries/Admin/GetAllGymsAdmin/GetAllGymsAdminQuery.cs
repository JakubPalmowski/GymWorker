using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllGymsAdmin
{
    public record class GetAllGymsAdminQuery(string status) : IRequest<List<GymAdminInfoResponse>>
    {
    }
}

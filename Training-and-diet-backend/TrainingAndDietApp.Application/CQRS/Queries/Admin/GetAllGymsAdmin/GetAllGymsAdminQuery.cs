using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllGymsAdmin
{
    public record GetAllGymsAdminQuery(string Status) : IRequest<List<GymAdminInfoResponse>>
    {
    }
}

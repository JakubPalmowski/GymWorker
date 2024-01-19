using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAllPendingGyms
{
    public class GetAllPendingGymsQuery : IRequest<List<GymAdminInfoResponse>>
    {
    }
}

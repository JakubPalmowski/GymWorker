using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAllGymsAddedByUser
{
    public record class GetAllGymsAddedByUserQuery(int idUser) : IRequest<List<GymsAddedByUserResponse>>
    {

    }
}

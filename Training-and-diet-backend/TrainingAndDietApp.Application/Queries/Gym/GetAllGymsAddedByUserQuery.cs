using MediatR;

namespace TrainingAndDietApp.Application.Queries.Gym
{
    public record class GetAllGymsAddedByUserQuery(int idUser) : IRequest<List<GymsAddedByUserResponse>>
    {

    }
}

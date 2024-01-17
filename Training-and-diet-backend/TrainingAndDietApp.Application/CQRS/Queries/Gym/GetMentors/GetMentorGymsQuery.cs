using MediatR;
using System.Collections.Generic;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetMentors
{
    public record class GetMentorGymsQuery(int idMentor) : IRequest<List<GymResponse>>
    {
    }
}

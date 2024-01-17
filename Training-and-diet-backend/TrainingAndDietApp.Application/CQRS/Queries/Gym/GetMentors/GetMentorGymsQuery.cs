using MediatR;
using System.Collections.Generic;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetMentors
{
    public record class GetMentorActiveGymsQuery(int idMentor) : IRequest<List<ActiveGymResponse>>
    {
    }
}

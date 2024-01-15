using MediatR;
using System.Collections.Generic;
using TrainingAndDietApp.Application.Responses.Gym;

namespace TrainingAndDietApp.Application.Queries.Gym
{
    public record class GetMentorActiveGymsQuery(int idMentor) : IRequest<List<ActiveGymResponse>>
    {
    }
}

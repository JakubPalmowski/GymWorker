using MediatR;
using System.Collections.Generic;
using TrainingAndDietApp.Application.Responses.Gym;

namespace TrainingAndDietApp.Application.Queries.Gym
{
    public record class GetMentorGymsQuery(int idMentor) : IRequest<List<GymResponse>>
    {
    }
}

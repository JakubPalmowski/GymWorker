using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Responses.Gym;

namespace TrainingAndDietApp.Application.Queries.Gym
{
    public class GetGymsQuery : IRequest<IEnumerable<GymResponse>>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAll
{
    public class GetActiveGymsQuery : IRequest<IEnumerable<ActiveGymResponse>>
    {
    }
}

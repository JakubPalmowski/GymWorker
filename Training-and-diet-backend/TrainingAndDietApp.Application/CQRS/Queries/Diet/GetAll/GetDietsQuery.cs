using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetAll
{
    public class GetDietsQuery : IRequest<IEnumerable<DietResponse>>
    {
    }
}

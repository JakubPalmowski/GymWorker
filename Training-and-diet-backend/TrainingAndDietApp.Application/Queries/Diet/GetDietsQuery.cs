using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Responses.Diet;

namespace TrainingAndDietApp.Application.Queries.Diet
{
    public class GetDietsQuery : IRequest<IEnumerable<DietResponse>>
    {
    }
}

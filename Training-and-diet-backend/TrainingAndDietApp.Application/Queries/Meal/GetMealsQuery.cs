using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Responses.Meal;

namespace TrainingAndDietApp.Application.Queries.Meal
{
    public class GetMealsQuery : IRequest<IEnumerable<MealResponse>>
    {

    }
}

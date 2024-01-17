using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Meal;

namespace TrainingAndDietApp.Application.CQRS.Queries.Meal.GetAll
{
    public class GetMealsQuery : IRequest<IEnumerable<MealResponse>>
    {

    }
}

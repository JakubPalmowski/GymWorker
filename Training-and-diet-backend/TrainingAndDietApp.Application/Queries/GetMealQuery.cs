using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Responses;

namespace TrainingAndDietApp.Application.Queries
{
    public class GetMealQuery : IRequest<MealResponse>
    {
        public int IdMeal { get;}

        public GetMealQuery(int idMeal)
        {
            IdMeal = idMeal;
        }
    }
}

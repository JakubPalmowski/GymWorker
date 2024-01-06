using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrainingAndDietApp.Application.Commands.Meal
{
    public class DeleteMealCommand : IRequest
    {
        public DeleteMealCommand(int mealId)
        {
            MealId = mealId;
        }

        public int MealId { get; }
    }
}

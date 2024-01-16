using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Meal.DeleteMeal
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

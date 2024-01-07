using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrainingAndDietApp.Application.Commands.Meal
{
    public class UpdateMealInternalCommand : IRequest
    {
        public UpdateMealInternalCommand(int idMeal, UpdateMealCommand mealCommand)
        {
            IdMeal = idMeal;
            MealCommand = mealCommand;
        }

        public int IdMeal { get; }
        public UpdateMealCommand MealCommand { get; }




    }
}

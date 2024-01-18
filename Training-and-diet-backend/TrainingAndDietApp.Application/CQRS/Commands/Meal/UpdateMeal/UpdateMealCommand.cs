using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Meal.UpdateMeal
{
    public class UpdateMealCommand : IRequest
    {

        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string PrepareSteps { get; set; }
        public string Kcal { get; set; }

        public UpdateMealCommand(string name, string ingredients, string prepareSteps, string kcal)
        {
            Name = name;
            Ingredients = ingredients;
            PrepareSteps = prepareSteps;
            Kcal = kcal;
        }
    }
}

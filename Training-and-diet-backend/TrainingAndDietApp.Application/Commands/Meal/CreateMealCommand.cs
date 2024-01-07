using MediatR;
using TrainingAndDietApp.Application.Responses.Meal;

namespace TrainingAndDietApp.Application.Commands.Meal
{
    public class CreateMealCommand : IRequest<MealResponse>
    {
        public int IdDietician { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string PrepareSteps { get; set; }
        public byte[]? Image { get; set; }
        public string Kcal { get; set; }
    }
}

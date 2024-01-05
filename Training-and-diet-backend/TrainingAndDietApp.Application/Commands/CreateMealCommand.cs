using MediatR;
using TrainingAndDietApp.Application.Responses;

namespace TrainingAndDietApp.Application.Commands
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

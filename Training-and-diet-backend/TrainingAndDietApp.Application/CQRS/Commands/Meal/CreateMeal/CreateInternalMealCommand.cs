using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Meal;

namespace TrainingAndDietApp.Application.CQRS.Commands.Meal.CreateMeal;

public record CreateInternalMealCommand(int IdDietician, CreateMealCommand MealCommand) : IRequest;

public class CreateMealCommand : IRequest<MealResponse>
{
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string PrepareSteps { get; set; }
    public string Kcal { get; set; }
}
using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Update
{
    public record UpdateMealDietInternalCommand(int IdMealDiet, int IdDietician, UpdateMealDietCommand UpdateMealDietCommand) : IRequest;

    public class UpdateMealDietCommand
    {
        public string? Comments { get; set; }
        public int DayOfWeek { get; set; }
        public string HourOfMeal { get; set; }
    }
}

using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Create
{
    public record CreateMealDietInternalCommand(int IdDietician, CreateMealDietCommand CreateMealDietCommand) : IRequest<CreateMealDietResponse>;
    
    public class CreateMealDietCommand
    {
        public int IdDiet { get; set; }
        public int IdMeal { get; set; }
        public string? Comments { get; set; }
        public int DayOfWeek { get; set; }
        public string HourOfMeal { get; set; }
    }
    public class CreateMealDietResponse
    {
        public int IdDietMeal { get; set; }
    }
}

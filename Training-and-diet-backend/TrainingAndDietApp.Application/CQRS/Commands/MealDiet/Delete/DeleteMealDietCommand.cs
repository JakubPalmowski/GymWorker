using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Delete
{
    public record DeleteMealDietCommand(int IdMealDiet,int IdDietician) : IRequest;
    
    
}

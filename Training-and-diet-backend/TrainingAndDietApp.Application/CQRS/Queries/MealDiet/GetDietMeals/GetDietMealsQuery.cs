using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.MealDiet;


namespace TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetDietMeals
{
    public record GetDietMealsQuery(int IdDiet, int IdDietician) : IRequest<List<MealDietMentorListResponse>>;
   
}

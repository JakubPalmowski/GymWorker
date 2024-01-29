using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.MealDiet;

namespace TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetMealDietForMentor
{
    public record GetMealDietForMentorQuery(int IdMealDiet,int IdDietician) : IRequest<MealDietForMentorResponse>;

}

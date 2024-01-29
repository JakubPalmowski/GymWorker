using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.MealDiet;

namespace TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetMealDietForPupil
{
    public record GetMealDietForPupilQuery(int IdMealDiet, int IdPupil) : IRequest<MealDietForPupilResponse>;

}

using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Meal;

namespace TrainingAndDietApp.Application.CQRS.Queries.Meal.GetByDieticianId;

public class GetMealsByDieticianIdQuery : IRequest<IEnumerable<MealResponse>>
{
    public int DieticianId { get; }

    public GetMealsByDieticianIdQuery(int dieticianId)
    {
        DieticianId = dieticianId;
    }
}
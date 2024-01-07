using MediatR;
using TrainingAndDietApp.Application.Responses.Meal;

namespace TrainingAndDietApp.Application.Queries.Meal;

public class GetMealsByDieticianIdQuery : IRequest<IEnumerable<MealResponse>>
{
    public int DieticianId { get; }

    public GetMealsByDieticianIdQuery(int dieticianId)
    {
        DieticianId = dieticianId;
    }
}
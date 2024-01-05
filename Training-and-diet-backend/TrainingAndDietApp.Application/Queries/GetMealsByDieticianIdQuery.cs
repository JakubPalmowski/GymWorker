using MediatR;
using TrainingAndDietApp.Application.Responses;

namespace TrainingAndDietApp.Application.Queries;

public class GetMealsByDieticianIdQuery :  IRequest <IEnumerable<MealResponse>>
{
    public int DieticianId { get; }

    public GetMealsByDieticianIdQuery(int dieticianId)
    {
        DieticianId = dieticianId;
    }
}
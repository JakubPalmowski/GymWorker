using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetDieticianDiets
{
    public record GetDieticianDietsQuery(int IdDietician) : IRequest<List<DietDieticianListResponse>>;
}

using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetPupilDiets
{
    public record GetPupilDietsQuery(int IdPupil) : IRequest<List<DietPupilListResponse>>;
   
}

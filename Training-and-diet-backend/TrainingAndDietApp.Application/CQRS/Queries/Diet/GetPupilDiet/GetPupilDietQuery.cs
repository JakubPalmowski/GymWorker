using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetPupilDiet
{
    public record GetPupilDietQuery(int IdDiet, int IdPupil) : IRequest<DietPupilResponse>;
    
}

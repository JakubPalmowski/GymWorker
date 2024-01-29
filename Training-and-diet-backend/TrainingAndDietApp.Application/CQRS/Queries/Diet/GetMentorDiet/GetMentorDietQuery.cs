using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetMentorDiet
{
    public record GetMentorDietQuery(int IdDiet,int IdDietician) : IRequest<DietMentorResponse>;
 
}

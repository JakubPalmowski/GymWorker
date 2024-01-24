using MediatR;
using TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll;

namespace TrainingAndDietApp.Application.CQRS.Queries.Opinion.GetOpinionById
{
    public record GetOpinionByIdQuery(int IdPupil, int IdMentor) : IRequest<OpinionEditResponse>;
   
    public class OpinionEditResponse
    {
        public string Content { get; set; }
        public decimal Rate { get; set; }
    }
}

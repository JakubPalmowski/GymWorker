using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Opinion.CreateOpinion
{
    public record CreateOpinionInternalCommand(int IdPupil, CreateOpinionCommand OpinionCommand) : IRequest;
    
    public class CreateOpinionCommand 
    {

        public int IdMentor { get; set; }

        public string Content { get; set; }

        public decimal Rate { get; set; }
    }
}

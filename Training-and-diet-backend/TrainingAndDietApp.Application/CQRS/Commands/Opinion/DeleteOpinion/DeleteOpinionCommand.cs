using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Opinion.DeleteOpinion
{
    public record DeleteOpinionCommand(int IdPupil,int IdMentor) : IRequest;
  
}

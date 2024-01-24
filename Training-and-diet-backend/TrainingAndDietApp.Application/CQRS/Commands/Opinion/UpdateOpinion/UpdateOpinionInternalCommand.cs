using MediatR;
using TrainingAndDietApp.Application.CQRS.Commands.Opinion.CreateOpinion;

namespace TrainingAndDietApp.Application.CQRS.Commands.Opinion.UpdateOpinion
{
    public record UpdateOpinionInternalCommand(int IdPupil, CreateOpinionCommand UpdateCommand) : IRequest;

}

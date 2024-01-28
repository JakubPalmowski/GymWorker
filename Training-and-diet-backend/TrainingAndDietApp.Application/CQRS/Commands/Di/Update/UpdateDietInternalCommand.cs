using MediatR;
using TrainingAndDietApp.Application.CQRS.Commands.Di.Create;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Update
{
    public record UpdateDietInternalCommand(int IdDiet,int IdDietician, CreateDietCommand CreateDietCommand) : IRequest;
    
}

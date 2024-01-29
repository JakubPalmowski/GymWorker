using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Create
{
    public record CreateDietInternalCommand(int IdDietician, CreateDietCommand CreateDietCommand) : IRequest<CreateDietResponse>;
    
}

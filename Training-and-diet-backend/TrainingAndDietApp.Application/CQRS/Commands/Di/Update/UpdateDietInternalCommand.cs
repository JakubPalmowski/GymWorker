using MediatR;
using TrainingAndDietApp.Application.CQRS.Commands.Di.Create;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Update
{
    public record UpdateDietInternalCommand(int IdDiet,int IdDietician, UpdateDietCommand CreateDietCommand) : IRequest;

    public class UpdateDietCommand
    {
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfWeeks { get; set; }
        public int TotalKcal { get; set; }
    }
}

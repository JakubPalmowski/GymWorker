using MediatR;

namespace TrainingAndDietApp.Application.Commands.TrainingPlan;

public class UpdateTrainingPlanCommand : IRequest
{
    public string Name { get; set; }
    public string CustomName { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public int NumberOfWeeks { get; set; }

}
using MediatR;
using TrainingAndDietApp.Application.Responses.TrainingPlan;

namespace TrainingAndDietApp.Application.Queries.TrainingPlan;

public record GetTrainerTrainingPlansQuery(int IdTrainer) : IRequest<IEnumerable<GetTrainerTrainingPlansResponse>>
{
}

public class GetTrainerTrainingPlansResponse
{
    public int IdTrainingPlan { get; set; }
    public string Name { get; set; }
    public string CustomName { get; set; }
    public int PlanDuration { get; set;}
}
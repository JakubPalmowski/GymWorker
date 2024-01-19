using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.AssignPupil;

public record AssignPupilToTrainingPlanInternalCommand(int IdTrainingPlan, int IdTrainer, AssignPupilToTrainingPlanCommand AssignPupilToTrainingPlanCommand) : IRequest
{
  
}

public class AssignPupilToTrainingPlanCommand
{
    public int IdPupil { get; set; }
}


using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.UpdateTrainingPlan;

public record UpdateTrainingPlanInternalCommand(int IdTrainingPlan, UpdateTrainingPlanCommand UpdateTrainingPlanCommand) : IRequest;
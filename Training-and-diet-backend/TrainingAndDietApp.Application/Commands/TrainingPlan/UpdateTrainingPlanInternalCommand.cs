using MediatR;

namespace TrainingAndDietApp.Application.Commands.TrainingPlan;

public record  UpdateTrainingPlanInternalCommand (int IdTrainingPlan, UpdateTrainingPlanCommand UpdateTrainingPlanCommand) : IRequest;
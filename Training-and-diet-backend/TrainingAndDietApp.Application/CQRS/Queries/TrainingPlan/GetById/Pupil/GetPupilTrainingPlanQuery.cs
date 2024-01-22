using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById.Pupil;

public record GetPupilTrainingPlanQuery(int IdTrainingPlan, int LoggedUser) : IRequest<PupilTrainingPlanResponse>;


public class PupilTrainingPlanResponse
{
    public int IdTrainingPlan { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime? EndDate { get; set; }
    public int IdTrainer { get; set; }
    public string TrainerName { get; set; }
    public string TrainerLastName { get; set; }
    
    
}
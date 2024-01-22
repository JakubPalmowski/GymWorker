using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByPupilId;

public record GetPupilTrainingPlansQuery(int LoggedUser) : IRequest<IEnumerable<GetPupilTrainingPlansResponse>>
{
}

public class GetPupilTrainingPlansResponse
{
    public int IdTrainingPlan { get; set; }
    public string Name { get; set; }
    public DateTime? EndDate { get; set; } 
    public int IdTrainer { get; set; }
    public string TrainerName { get; set; }
    public string TrainerLastName { get; set; }

}
    

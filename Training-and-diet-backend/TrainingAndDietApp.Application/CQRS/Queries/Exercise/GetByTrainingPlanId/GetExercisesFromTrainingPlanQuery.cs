using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainingPlanId;

public class GetExercisesFromTrainingPlanQuery : IRequest<IEnumerable<TraineeExerciseResponse>>
{
    public GetExercisesFromTrainingPlanQuery(int idTrainingPlan)
    {
        IdTrainingPlan = idTrainingPlan;
    }

    public int IdTrainingPlan { get; set; }
}
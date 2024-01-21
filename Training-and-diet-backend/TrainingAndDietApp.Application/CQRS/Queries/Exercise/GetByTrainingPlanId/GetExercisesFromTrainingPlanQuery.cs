using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainingPlanId;

public class GetExercisesFromTrainingPlanQuery : IRequest<IEnumerable<TrainerTraineeExerciseResponse>>
{
    public GetExercisesFromTrainingPlanQuery(int idTrainingPlan)
    {
        IdTrainingPlan = idTrainingPlan;
    }

    public int IdTrainingPlan { get; set; }
}
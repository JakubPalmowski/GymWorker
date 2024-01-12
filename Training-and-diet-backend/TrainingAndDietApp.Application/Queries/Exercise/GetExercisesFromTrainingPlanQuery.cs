using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Application.Responses.TraineeExercise;

namespace TrainingAndDietApp.Application.Queries.Exercise;

public class GetExercisesFromTrainingPlanQuery : IRequest<IEnumerable<TraineeExerciseResponse>>
{
    public GetExercisesFromTrainingPlanQuery(int idTrainingPlan)
    {
        IdTrainingPlan = idTrainingPlan;
    }

    public int IdTrainingPlan { get; set;}
}
using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;

namespace TrainingAndDietApp.Application.Queries.Exercise;

public class GetExercisesFromTrainingPlanQuery : IRequest<IEnumerable<ExerciseResponse>>
{
    public GetExercisesFromTrainingPlanQuery(int idTrainingPlan)
    {
        IdTrainingPlan = idTrainingPlan;
    }

    public int IdTrainingPlan { get; set;}
}
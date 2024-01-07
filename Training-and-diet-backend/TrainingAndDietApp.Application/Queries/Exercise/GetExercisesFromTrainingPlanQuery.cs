using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;

namespace TrainingAndDietApp.Application.Queries.Exercise;

public class GetExercisesFromTrainingPlanQuery : IRequest<IEnumerable<ExerciseNameResponse>>
{
    public GetExercisesFromTrainingPlanQuery(int idTrainingPlan)
    {
        IdTrainingPlan = idTrainingPlan;
    }

    public int IdTrainingPlan { get; set;}
}
using MediatR;
using TrainingAndDietApp.Application.Responses.Exercise;

namespace TrainingAndDietApp.Application.Queries.Exercise
{
    public class GetExerciseQuery : IRequest<ExerciseResponse>
    {
        public GetExerciseQuery(int idExercise)
        {
            IdExercise = idExercise;
        }
        public int IdExercise { get; set; }

    }
}
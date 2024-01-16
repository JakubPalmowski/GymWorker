using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetById
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
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById;

public record GetTraineeExerciseQuery(int IdTraineeExercise) : IRequest<TraineeExerciseResponse>
{

}
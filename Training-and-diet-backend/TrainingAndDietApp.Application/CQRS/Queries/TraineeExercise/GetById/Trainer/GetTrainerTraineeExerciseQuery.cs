using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;

namespace TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById.Trainer;

public record GetTrainerTraineeExerciseQuery(int IdTraineeExercise, int LoggedUser) : IRequest<TrainerTraineeExerciseResponse>
{

}
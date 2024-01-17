using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.DeleteTraineeExercise;

public record DeleteTraineeExerciseCommand(int IdTraineeExercise) : IRequest
{

}
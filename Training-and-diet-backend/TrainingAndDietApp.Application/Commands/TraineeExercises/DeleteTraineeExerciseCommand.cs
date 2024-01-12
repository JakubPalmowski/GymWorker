using MediatR;

namespace TrainingAndDietApp.Application.Commands.TraineeExercises;

public record DeleteTraineeExerciseCommand (int IdTraineeExercise) : IRequest
{
    
}
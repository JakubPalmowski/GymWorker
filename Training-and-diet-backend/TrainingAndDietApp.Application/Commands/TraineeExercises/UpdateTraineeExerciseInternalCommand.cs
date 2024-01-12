using MediatR;

namespace TrainingAndDietApp.Application.Commands.TraineeExercises;

public class UpdateTraineeExerciseInternalCommand : IRequest
{
    public UpdateTraineeExerciseInternalCommand(int idTraineeExercise,
        UpdateTraineeExerciseCommand traineeExerciseCommand)
    {
        IdTraineeExercise = idTraineeExercise;
        TraineeExerciseCommand = traineeExerciseCommand;
    }

    public int IdTraineeExercise { get; }
    public UpdateTraineeExerciseCommand TraineeExerciseCommand { get;}
    
}
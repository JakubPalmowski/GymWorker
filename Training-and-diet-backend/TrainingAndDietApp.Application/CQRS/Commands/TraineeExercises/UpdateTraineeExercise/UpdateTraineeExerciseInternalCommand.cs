using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.UpdateTraineeExercise;

public class UpdateTraineeExerciseInternalCommand : IRequest
{
    public UpdateTraineeExerciseInternalCommand(int idTraineeExercise,
        UpdateTraineeExerciseCommand traineeExerciseCommand)
    {
        IdTraineeExercise = idTraineeExercise;
        TraineeExerciseCommand = traineeExerciseCommand;
    }

    public int IdTraineeExercise { get; }
    public UpdateTraineeExerciseCommand TraineeExerciseCommand { get; }

}
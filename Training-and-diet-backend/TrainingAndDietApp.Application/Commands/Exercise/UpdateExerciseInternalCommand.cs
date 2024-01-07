using MediatR;

namespace TrainingAndDietApp.Application.Commands.Exercise;

public class UpdateExerciseInternalCommand : IRequest
{
    public UpdateExerciseInternalCommand(int idExercise, UpdateExerciseCommand exerciseCommand)
    {
        IdExercise = idExercise;
        ExerciseCommand = exerciseCommand;
    }

    public int IdExercise { get; }
    public UpdateExerciseCommand ExerciseCommand { get; }
}
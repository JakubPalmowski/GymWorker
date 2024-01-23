using MediatR;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.UpdateExercise;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateExercise
{
    public class UpdateAdminExerciseInternalCommand : IRequest
    {
        public UpdateAdminExerciseInternalCommand(int idExercise, UpdateExerciseCommand exerciseCommand)
    {
        IdExercise = idExercise;
        ExerciseCommand = exerciseCommand;
    }

    public int IdExercise { get; }
    public UpdateExerciseCommand ExerciseCommand { get; }


    }
}

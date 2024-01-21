using MediatR;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.CreateExercise
{
    public class CreateExerciseAdminInternalCommand : IRequest<ExerciseNameResponse>
    {
        public CreateExerciseAdminInternalCommand(CreateExerciseCommand exerciseCommand)
        {
            ExerciseCommand = exerciseCommand;
        }
        public CreateExerciseCommand ExerciseCommand { get; }
    }
}

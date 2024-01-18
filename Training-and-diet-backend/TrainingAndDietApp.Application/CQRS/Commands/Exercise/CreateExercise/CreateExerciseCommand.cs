using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise
{
    public class CreateExerciseCommand 
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string ExerciseSteps { get; set; }

    }

    public class CreateInternalExerciseCommand : IRequest<ExerciseNameResponse>
    {
        public CreateInternalExerciseCommand(int idTrainer, CreateExerciseCommand exerciseCommand)
        {
            IdTrainer = idTrainer;
            ExerciseCommand = exerciseCommand;
        }

        public int IdTrainer { get; }
        public CreateExerciseCommand ExerciseCommand { get; }
    }
}
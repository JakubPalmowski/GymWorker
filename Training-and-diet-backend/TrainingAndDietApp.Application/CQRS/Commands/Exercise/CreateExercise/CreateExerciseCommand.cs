using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;

namespace TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise
{
    public class CreateExerciseCommand : IRequest<ExerciseNameResponse>
    {


        public string Name { get; set; }
        public string Details { get; set; }
        public string ExerciseSteps { get; set; }
        public int IdTrainer { get; set; }


    }
}
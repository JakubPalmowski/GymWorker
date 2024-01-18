using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Exercise.UpdateExercise;

public class UpdateExerciseCommand : IRequest
{
    public string Name { get; set; }
    public string Details { get; set; }
    public string ExerciseSteps { get; set; }
}
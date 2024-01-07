using MediatR;

namespace TrainingAndDietApp.Application.Commands.Exercise;

public class UpdateExerciseCommand : IRequest
{
    public string Name { get; set; }
    public string Details { get; set; }
    public string ExerciseSteps { get; set; }
    public byte[]? Image { get; set; }
}
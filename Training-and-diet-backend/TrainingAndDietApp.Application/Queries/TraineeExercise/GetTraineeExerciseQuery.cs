using MediatR;
using TrainingAndDietApp.Application.Responses.TraineeExercise;

namespace TrainingAndDietApp.Application.Queries.TraineeExercise;

public record GetTraineeExerciseQuery (int IdTraineeExercise) : IRequest<TraineeExerciseResponse>
{
    
}
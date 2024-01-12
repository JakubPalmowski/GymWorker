using MediatR;
using TrainingAndDietApp.Application.Responses;

namespace TrainingAndDietApp.Application.Queries.TraineeExercise;

public record GetTraineeExerciseQuery (int IdTraineeExercise) : IRequest<TraineeExerciseResponse>
{
    
}
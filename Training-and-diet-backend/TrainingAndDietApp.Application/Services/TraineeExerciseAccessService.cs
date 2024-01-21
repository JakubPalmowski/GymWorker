using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Services;

public class TraineeExerciseAccessService : ITraineeExerciseAccessService
{
    private readonly ITraineeExercisesRepository _traineeExerciseRepository;


    public TraineeExerciseAccessService(ITraineeExercisesRepository traineeExerciseRepository)
    {
        _traineeExerciseRepository = traineeExerciseRepository;
    }
    public async Task<bool> IsAccessibleByTrainer(int idTraineeExercise, int mentorId, CancellationToken cancellationToken)
    {
        var traineeExercise = await _traineeExerciseRepository.GetTraineeExerciseWithTrainingPlanAndTrainerByIdAsync(idTraineeExercise, cancellationToken);

        if (traineeExercise == null)
            return false;
        

        return traineeExercise.TrainingPlan.IdTrainer == mentorId;
    }

    public async Task<bool> IsAccessibleByPupil(int idTrainingPlan, int pupilId, CancellationToken cancellation)
    {
        var traineeExercise = await _traineeExerciseRepository.GetTraineeExerciseWithTrainingPlanAndPupilByIdAsync(idTrainingPlan, cancellation);

        if (traineeExercise == null)
            return false;


        return traineeExercise.TrainingPlan.IdPupil == pupilId;
    }
}
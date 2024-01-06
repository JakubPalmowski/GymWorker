using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Services;

public class TraineeExerciseService : ITraineeExerciseService
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public TraineeExerciseService(ITrainingPlanRepository trainingPlanRepository, IExerciseRepository exerciseRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<bool> IsTrainingPlanValid(int trainingPlanId)
    {
        return await _trainingPlanRepository.CheckIfTrainingPlanExists(trainingPlanId, CancellationToken.None);
    }
    public async Task<bool> IsExerciseValid(int trainingPlanId)
    {
        return await _exerciseRepository.CheckIfExerciseExists(trainingPlanId);
    }
}
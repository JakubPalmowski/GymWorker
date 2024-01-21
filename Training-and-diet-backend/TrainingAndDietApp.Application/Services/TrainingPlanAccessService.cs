using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.Services;

public class TrainingPlanAccessService : ITrainingPlanAccessService
{
    private readonly IRepository<TrainingPlan> _trainingPlanRepository;
   

    public TrainingPlanAccessService(IRepository<TrainingPlan> trainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
    }

    public async Task<bool> IsAccessibleByTrainer(int trainingPlanId, int mentorId, CancellationToken cancellation)
    {
        var trainingPlan = await _trainingPlanRepository.GetByIdAsync(trainingPlanId, cancellation);

        if (trainingPlan == null)
        {
            return false;
        }
        
        return trainingPlan.IdTrainer == mentorId;
    }
    public async Task<bool> IsAccessibleByPupil(int trainingPlanId, int pupilId, CancellationToken cancellation)
    {
        var trainingPlan = await _trainingPlanRepository.GetByIdAsync(trainingPlanId, cancellation);

        if (trainingPlan == null)
        {
            return false;
        }

        return trainingPlan.IdPupil == pupilId;
    }


}
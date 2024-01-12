using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TrainingPlan;

public class UpdateTrainingPlanCommandHandler : IRequestHandler<UpdateTrainingPlanInternalCommand>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly IMapper _mapper;
    public UpdateTrainingPlanCommandHandler(IMapper mapper, ITrainingPlanRepository trainingPlanRepository)
    {
        _mapper = mapper;
        _trainingPlanRepository = trainingPlanRepository;
    }
    public async Task Handle(UpdateTrainingPlanInternalCommand request, CancellationToken cancellationToken)
    {
        var trainingPlan = await _trainingPlanRepository.GetTrainingPlanByIdAsync(request.IdTrainingPlan, cancellationToken);
        if (trainingPlan == null)
            throw new NotFoundException("Training plan not found");

        _mapper.Map(request, trainingPlan);
        await _trainingPlanRepository.UpdateTrainingPlanAsync(trainingPlan, cancellationToken);
    }
}
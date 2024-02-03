using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByTrainerId;

public class GetTrainerTrainingPlansQueryHandler : IRequestHandler<GetTrainerTrainingPlansQuery, IEnumerable<GetTrainerTrainingPlansResponse>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly IMapper _mapper;
    public GetTrainerTrainingPlansQueryHandler(IMapper mapper, ITrainingPlanRepository trainingPlanRepository)
    {
        _mapper = mapper;
        _trainingPlanRepository = trainingPlanRepository;
    }
    public async Task<IEnumerable<GetTrainerTrainingPlansResponse>> Handle(GetTrainerTrainingPlansQuery request, CancellationToken cancellationToken)
    {
        var trainingPlans = await _trainingPlanRepository.GetTrainerTrainingPlans(request.IdTrainer, cancellationToken);
        if (!trainingPlans.Any())
            throw new NotFoundException("Trainer has no training plans");

        
        return _mapper.Map<List<GetTrainerTrainingPlansResponse>>(trainingPlans);

    }
}
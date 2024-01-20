using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByTrainerId;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByPupilId;

public class GetPupilTrainingPlansQueryHandler : IRequestHandler<GetPupilTrainingPlansQuery, IEnumerable<GetPupilTrainingPlansResponse>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly IMapper _mapper;

    public GetPupilTrainingPlansQueryHandler(ITrainingPlanRepository trainingPlanRepository, IMapper mapper)
    {
        _trainingPlanRepository = trainingPlanRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetPupilTrainingPlansResponse>> Handle(GetPupilTrainingPlansQuery request, CancellationToken cancellationToken)
    {
        var trainingPlans = await _trainingPlanRepository.GetTrainingPlansWithTrainerByPupilId(request.IdPupil, cancellationToken);
        if (trainingPlans == null)
            throw new NotFoundException("Trainer has no training plans");

        return _mapper.Map<List<GetPupilTrainingPlansResponse>>(trainingPlans);
    }
}
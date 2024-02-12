using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById.Pupil;

public class GetPupilTrainingPlanQueryHandler : IRequestHandler<GetPupilTrainingPlanQuery, PupilTrainingPlanResponse>
{
    private readonly ITrainingPlanRepository _planRepository;
    private readonly IMapper _mapper;
    public GetPupilTrainingPlanQueryHandler(IMapper mapper, ITrainingPlanRepository planRepository)
    {
        _mapper = mapper;
        _planRepository = planRepository;
    }
    public async Task<PupilTrainingPlanResponse> Handle(GetPupilTrainingPlanQuery request, CancellationToken cancellationToken)
    {
        var trainingPlan = await _planRepository.GetByIdWithTrainer(request.IdTrainingPlan, cancellationToken);
        if (trainingPlan == null)
            throw new NotFoundException("Training plan not found");

        return _mapper.Map<PupilTrainingPlanResponse>(trainingPlan);
    }
}
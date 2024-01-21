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
    private readonly ITrainingPlanAccessService _trainingPlanAccessService;
    public GetPupilTrainingPlanQueryHandler(IMapper mapper, ITrainingPlanAccessService trainingPlanAccessService, ITrainingPlanRepository planRepository)
    {
        _mapper = mapper;
        _trainingPlanAccessService = trainingPlanAccessService;
        _planRepository = planRepository;
    }
    public async Task<PupilTrainingPlanResponse> Handle(GetPupilTrainingPlanQuery request, CancellationToken cancellationToken)
    {
        var trainingPlan = await _planRepository.GetByIdWithTrainer(request.IdTrainingPlan, cancellationToken);
        if (trainingPlan == null)
            throw new NotFoundException("Training plan not found");

        var isAccessible = await _trainingPlanAccessService.IsAccessibleByPupil(request.IdTrainingPlan, request.LoggedUser, cancellationToken);
        if (!isAccessible)
            throw new ForbiddenException("You are not allowed to access this training plan");

        return _mapper.Map<PupilTrainingPlanResponse>(trainingPlan);
    }
}
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById
{
    public class GetTrainingPlanQueryHandler : IRequestHandler<GetTrainingPlanQuery, TrainingPlanResponse>
    {
        private readonly ITrainingPlanRepository _planRepository;
        private readonly IMapper _mapper;
        private readonly ITrainingPlanAccessService _trainingPlanAccessService;
        public GetTrainingPlanQueryHandler(IMapper mapper, ITrainingPlanAccessService trainingPlanAccessService, ITrainingPlanRepository planRepository)
        {
            _mapper = mapper;
            _trainingPlanAccessService = trainingPlanAccessService;
            _planRepository = planRepository;
        }
        public async Task<TrainingPlanResponse> Handle(GetTrainingPlanQuery request, CancellationToken cancellationToken)
        {
            var trainingPlan = await _planRepository.GetByIdWithPupil(request.IdTrainingPlan, cancellationToken);
            if (trainingPlan == null)
                throw new NotFoundException("Training plan not found");

            var isAccessible = await _trainingPlanAccessService.IsAccessibleBy(request.IdTrainingPlan, request.LoggedUser, cancellationToken);
            if (!isAccessible)
                throw new ForbiddenException("You are not allowed to access this training plan");

            return _mapper.Map<TrainingPlanResponse>(trainingPlan);

        }
    }
}

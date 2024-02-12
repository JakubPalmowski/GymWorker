using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById.Trainer
{
    public class GetTrainerTrainingPlanQueryHandler : IRequestHandler<GetTrainerTrainingPlanQuery, TrainerTrainingPlanResponse>
    {
        private readonly ITrainingPlanRepository _planRepository;
        private readonly IMapper _mapper;
        public GetTrainerTrainingPlanQueryHandler(IMapper mapper, ITrainingPlanRepository planRepository)
        {
            _mapper = mapper;
            _planRepository = planRepository;
        }
        public async Task<TrainerTrainingPlanResponse> Handle(GetTrainerTrainingPlanQuery request, CancellationToken cancellationToken)
        {
            var trainingPlan = await _planRepository.GetByIdWithPupil(request.IdTrainingPlan, cancellationToken);
            if (trainingPlan == null)
                throw new NotFoundException("Training plan not found");

            return _mapper.Map<TrainerTrainingPlanResponse>(trainingPlan);

        }
    }
}

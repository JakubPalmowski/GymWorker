using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById
{
    public class GetTrainingPlanQueryHandler : IRequestHandler<GetTrainingPlanQuery, TrainingPlanResponse>
    {
        private readonly IRepository<Domain.Entities.TrainingPlan> _repository;
        private readonly IMapper _mapper;
        public GetTrainingPlanQueryHandler(IMapper mapper, IRepository<Domain.Entities.TrainingPlan> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<TrainingPlanResponse> Handle(GetTrainingPlanQuery request, CancellationToken cancellationToken)
        {
            var trainingPlan = await _repository.GetByIdAsync(request.IdTrainingPlan, cancellationToken);
            if (trainingPlan == null)
                throw new NotFoundException("Training plan not found");

            return _mapper.Map<TrainingPlanResponse>(trainingPlan);

        }
    }
}

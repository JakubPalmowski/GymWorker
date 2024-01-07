﻿using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.TrainingPlan;
using TrainingAndDietApp.Application.Responses.TrainingPlan;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TrainingPlan
{
    public class GetTrainingPlanQueryHandler : IRequestHandler<GetTrainingPlanQuery, TrainingPlanResponse>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IMapper _mapper;
        public GetTrainingPlanQueryHandler(IMapper mapper, ITrainingPlanRepository trainingPlanRepository)
        {
            _mapper = mapper;
            _trainingPlanRepository = trainingPlanRepository;
        }
        public async Task<TrainingPlanResponse> Handle(GetTrainingPlanQuery request, CancellationToken cancellationToken)
        {
            var trainingPlan = await _trainingPlanRepository.GetTrainingPlanByIdAsync(request.IdTrainingPlan, cancellationToken);
            if (trainingPlan == null)
                throw new NotFoundException("Training plan not found");

            return _mapper.Map<TrainingPlanResponse>(trainingPlan);
                         
        }
    }
}

using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TrainingPlan
{
    public class CreateTrainingPlanCommandHandler : IRequestHandler<CreateTrainingPlanCommand, CreateTrainingPlanResponse>
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateTrainingPlanCommandHandler(IMapper mapper, ITrainingPlanRepository trainingPlanRepository, IUserService userService)
        {
            _mapper = mapper;
            _trainingPlanRepository = trainingPlanRepository;
            _userService = userService;
        }
        public async Task<CreateTrainingPlanResponse> Handle(CreateTrainingPlanCommand request, CancellationToken cancellationToken)
        {
            if (! await _userService.CheckIfUserExists(request.IdTrainer, cancellationToken))
                throw new NotFoundException("User not found");
            if (! await _userService.CheckIfUserIsTrainer(request.IdTrainer, cancellationToken))
                throw new NotFoundException("User is not a trainer");

            var trainingPlan = _mapper.Map<Domain.Entities.TrainingPlan>(request);
            var id = await _trainingPlanRepository.AddTrainingPlanAsync(trainingPlan, cancellationToken);
            return new CreateTrainingPlanResponse {IdTrainingPlan = id};

        }
    }
}

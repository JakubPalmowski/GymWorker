using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TrainingPlan
{
    public class CreateTrainingPlanCommandHandler : IRequestHandler<CreateInternalTrainingPlanCommand, CreateTrainingPlanResponse>
    {
        private readonly IRepository<Domain.Entities.TrainingPlan> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateTrainingPlanCommandHandler(IMapper mapper, IRepository<Domain.Entities.TrainingPlan> repository, IUserService userService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateTrainingPlanResponse> Handle(CreateInternalTrainingPlanCommand request, CancellationToken cancellationToken)
        {
            if (! await _userService.CheckIfUserExists(request.IdTrainer, cancellationToken))
                throw new NotFoundException("User not found");
            if (! (await _userService.CheckIfUserIsTrainer(request.IdTrainer, cancellationToken) || await _userService.CheckIfUserIsDieticianTrainer(request.IdTrainer, cancellationToken)))
                throw new NotFoundException("User is not a trainer");

            var trainingPlan = _mapper.Map<Domain.Entities.TrainingPlan>(request.CreateTrainingPlanCommand);
            trainingPlan.IdTrainer = request.IdTrainer;
            await _repository.AddAsync(trainingPlan, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new CreateTrainingPlanResponse {IdTrainingPlan = trainingPlan.IdTrainingPlan};

        }
    }
}

using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Responses.Meal;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Meal
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, MealResponse>
    {
        private readonly IRepository<Domain.Entities.Meal> _repository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateMealCommandHandler(IRepository<Domain.Entities.Meal> repository, IMapper mapper, IUserRepository userRepository, IUserService userService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        public async Task<MealResponse> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            if (!await _userService.CheckIfUserExists(request.IdDietician, cancellationToken))
                throw new NotFoundException("User not found");

            if (!await _userService.CheckIfUserIsDietician(request.IdDietician, cancellationToken) || await _userService.CheckIfUserIsDieticianTrainer(request.IdDietician, cancellationToken))
                throw new BadRequestException("User is not a dietician");

            var result = _mapper.Map<Domain.Entities.Meal>(request);
            await _repository.AddAsync(result, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<MealResponse>(result);
        }

     
    }
}

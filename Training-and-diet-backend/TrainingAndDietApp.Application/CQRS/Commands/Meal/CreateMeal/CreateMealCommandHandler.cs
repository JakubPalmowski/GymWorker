using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.Meal;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Meal.CreateMeal
{
    public class CreateMealCommandHandler : IRequestHandler<CreateInternalMealCommand, MealResponse>
    {
        private readonly IRepository<Domain.Entities.Meal> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateMealCommandHandler(IRepository<Domain.Entities.Meal> repository, IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<MealResponse> Handle(CreateInternalMealCommand request, CancellationToken cancellationToken)
        {

            var result = _mapper.Map<Domain.Entities.Meal>(request);
            await _repository.AddAsync(result, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<MealResponse>(result);
        }


    }
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Create
{
    public class CreateDietMealCommandHandler : IRequestHandler<CreateMealDietInternalCommand, CreateMealDietResponse>
    {
        private readonly IRepository<Domain.Entities.MealDiet> _mealDietBaseRepository;
        private readonly IRepository<Domain.Entities.Meal> _mealBaseRepository;
        private readonly IRepository<Diet> _dietBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDietMealCommandHandler(IRepository<Domain.Entities.MealDiet> mealDietBaseRepository, IRepository<Domain.Entities.Meal> mealBaseRepository, IRepository<Domain.Entities.Diet> dietBaseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mealDietBaseRepository = mealDietBaseRepository;
            _mealBaseRepository = mealBaseRepository;
            _dietBaseRepository = dietBaseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateMealDietResponse> Handle(CreateMealDietInternalCommand request, CancellationToken cancellationToken)
        {
            var meal = await _mealBaseRepository.GetByIdAsync(request.CreateMealDietCommand.IdMeal, cancellationToken);
            var diet = await _dietBaseRepository.GetByIdAsync(request.CreateMealDietCommand.IdDiet, cancellationToken);
            if (meal == null || diet == null)
            {
                throw new NotFoundException("Meal or diet not found");
            }
            if(meal.IdDietician != request.IdDietician)
            {
                throw new BadRequestException("You can't add meal from another dietitian");
            }
            if(diet.IdDietician != request.IdDietician || meal.IdDietician != request.IdDietician)
            {
                throw new BadRequestException("You can't add meal to another dietitian's diet");
            }

            var mealDiet = _mapper.Map<Domain.Entities.MealDiet>(request);
            await _mealDietBaseRepository.AddAsync(mealDiet, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new CreateMealDietResponse()
            {
                IdDietMeal = mealDiet.IdMealDiet
            };
        }
    }
}

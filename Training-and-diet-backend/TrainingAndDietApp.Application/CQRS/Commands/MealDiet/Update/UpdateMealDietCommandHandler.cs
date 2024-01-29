using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Update
{
    public class UpdateMealDietCommandHandler : IRequestHandler<UpdateMealDietInternalCommand>
    {
        private readonly IRepository<Domain.Entities.MealDiet> _mealDietBaseRepository;
        private readonly IRepository<Domain.Entities.Meal> _mealBaseRepository;
        private readonly IRepository<Diet> _dietBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMealDietCommandHandler(IRepository<Domain.Entities.MealDiet> mealDietBaseRepository, IRepository<Domain.Entities.Meal> mealBaseRepository, IRepository<Domain.Entities.Diet> dietBaseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mealDietBaseRepository = mealDietBaseRepository;
            _mealBaseRepository = mealBaseRepository;
            _dietBaseRepository = dietBaseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdateMealDietInternalCommand request, CancellationToken cancellationToken)
        {
            var dietMeal = await _mealDietBaseRepository.GetByIdAsync(request.IdMealDiet, cancellationToken);
            if(dietMeal == null)
            {
                throw new Exceptions.NotFoundException("Meal diet not found");
            }
            var meal = await _mealBaseRepository.GetByIdAsync(dietMeal.IdMeal, cancellationToken);
            var diet = await _dietBaseRepository.GetByIdAsync(dietMeal.IdDiet, cancellationToken);
            if (meal == null || diet == null || meal.IdDietician != request.IdDietician || diet.IdDietician != request.IdDietician)
            {
                throw new Exceptions.NotFoundException("Meal or diet not found");
            }
            _mapper.Map(request, dietMeal);
            await _mealDietBaseRepository.UpdateAsync(dietMeal, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

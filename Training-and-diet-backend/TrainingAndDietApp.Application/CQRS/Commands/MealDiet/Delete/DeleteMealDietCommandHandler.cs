using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.MealDiet.Delete
{
    public class DeleteMealDietCommandHandler : IRequestHandler<DeleteMealDietCommand>
    {
        private readonly IRepository<Domain.Entities.MealDiet> _mealDietRepository;
        private readonly IRepository<Diet> _dietBaseRepository;
        private readonly IRepository<Domain.Entities.Meal> _mealBaseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMealDietCommandHandler(IRepository<Domain.Entities.MealDiet> mealDietRepository, IRepository<Domain.Entities.Diet> dietBaseRepository, IRepository<Domain.Entities.Meal> mealBaseRepository, IUnitOfWork unitOfWork)
        {
            _mealDietRepository = mealDietRepository;
            _dietBaseRepository = dietBaseRepository;
            _mealBaseRepository = mealBaseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMealDietCommand request, CancellationToken cancellationToken)
        {
            var mealDiet = await _mealDietRepository.GetByIdAsync(request.IdMealDiet, cancellationToken);
            if (mealDiet == null)
                throw new NotFoundException("Meal diet not found");
            
            var diet = await _dietBaseRepository.GetByIdAsync(mealDiet.IdDiet, cancellationToken);
            if (diet == null || diet.IdDietician != request.IdDietician)
                throw new NotFoundException("Diet not found");
            
            var meal = await _mealBaseRepository.GetByIdAsync(mealDiet.IdMeal, cancellationToken);
            if (meal == null || meal.IdDietician != request.IdDietician)
                throw new NotFoundException("Meal not found");
            
            await _mealDietRepository.DeleteAsync(request.IdMealDiet, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

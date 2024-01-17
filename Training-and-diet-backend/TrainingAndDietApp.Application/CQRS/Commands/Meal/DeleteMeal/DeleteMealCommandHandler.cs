using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Meal.DeleteMeal
{
    public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand>
    {
        private readonly IRepository<Domain.Entities.Meal> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMealCommandHandler(IRepository<Domain.Entities.Meal> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _repository.GetByIdAsync(request.MealId, cancellationToken);
            if (meal == null)
                throw new NotFoundException("Meal not found");

            await _repository.DeleteAsync(meal.IdMeal, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

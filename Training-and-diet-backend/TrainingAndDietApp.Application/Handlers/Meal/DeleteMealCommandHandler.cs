using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Meal
{
    public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand>
    {
        private readonly IMealRepository _mealRepository;


        public DeleteMealCommandHandler(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }
        public async Task Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetMealByIdAsync(request.MealId, cancellationToken);
            if (meal == null)
                throw new NotFoundException("Meal not found");

            await _mealRepository.DeleteMealAsync(meal.IdMeal, cancellationToken);
        }
    }
}

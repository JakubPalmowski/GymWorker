using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Commands;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealInternalCommand>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public UpdateMealCommandHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateMealInternalCommand request, CancellationToken cancellationToken)
        {
            var mealToUpdate = await _mealRepository.GetMealByIdAsync(request.IdMeal, cancellationToken);
            if (mealToUpdate == null)
                throw new NotFoundException("Meal not found");
            _mapper.Map(request, mealToUpdate);
            await _mealRepository.UpdateMealAsync(mealToUpdate, cancellationToken);
        }
    }
}

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Meal.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealInternalCommand>
    {
        private readonly IRepository<Domain.Entities.Meal> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMealCommandHandler(IRepository<Domain.Entities.Meal> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateMealInternalCommand request, CancellationToken cancellationToken)
        {
            var mealToUpdate = await _repository.GetByIdAsync(request.IdMeal, cancellationToken);
            if (mealToUpdate == null)
                throw new NotFoundException("Meal not found");
            _mapper.Map(request, mealToUpdate);
            await _repository.UpdateAsync(mealToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

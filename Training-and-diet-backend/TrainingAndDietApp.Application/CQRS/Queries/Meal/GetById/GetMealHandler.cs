using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Meal;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Meal.GetById
{
    public class GetMealHandler : IRequestHandler<GetMealQuery, MealResponse>
    {
        private readonly IRepository<Domain.Entities.Meal> _repository;
        private readonly IMapper _mapper;

        public GetMealHandler(IRepository<Domain.Entities.Meal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MealResponse> Handle(GetMealQuery request, CancellationToken cancellationToken)
        {
            var meal = await _repository.GetByIdAsync(request.IdMeal, cancellationToken);
            if (meal == null)
                throw new NotFoundException("Meal not found");
            return _mapper.Map<MealResponse>(meal);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.Meal;
using TrainingAndDietApp.Application.Responses.Meal;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Meal
{
    public class GetMealsHandler : IRequestHandler<GetMealsQuery, IEnumerable<MealResponse>>
    {
        private readonly IRepository<Domain.Entities.Meal> _repository;
        private readonly IMapper _mapper;

        public GetMealsHandler(IRepository<Domain.Entities.Meal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MealResponse>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var meals = await _repository.GetAllAsync(cancellationToken);
            if(!meals.Any())
                throw new NotFoundException("Meals not found");
            return _mapper.Map<List<MealResponse>>(meals);
        }
    }
}

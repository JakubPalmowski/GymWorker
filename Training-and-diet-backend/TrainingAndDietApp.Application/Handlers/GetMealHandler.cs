using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries;
using TrainingAndDietApp.Application.Responses;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers
{
    public class GetMealHandler : IRequestHandler<GetMealQuery, MealResponse>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetMealHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<MealResponse> Handle(GetMealQuery request, CancellationToken cancellationToken)
        {
           var meal = await _mealRepository.GetMealByIdAsync(request.IdMeal, cancellationToken);
           if (meal == null)
                throw new NotFoundException("Meal not found");
           return  _mapper.Map<MealResponse>(meal);
        }
    }
}

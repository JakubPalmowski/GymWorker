using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries;
using TrainingAndDietApp.Application.Responses;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers
{
    public class GetMealsHandler : IRequestHandler<GetMealsQuery,IEnumerable<MealResponse>>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetMealsHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MealResponse>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealsAsync();
            return _mapper.Map<List<MealResponse>>(meals);
        }
    }
}

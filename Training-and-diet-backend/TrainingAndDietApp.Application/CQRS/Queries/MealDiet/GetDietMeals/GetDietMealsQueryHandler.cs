using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.CQRS.Responses.MealDiet;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetDietMeals
{
    public class GetDietMealsQueryHandler : IRequestHandler<GetDietMealsQuery, List<MealDietMentorListResponse>>
    {
        private readonly IMealDietRepository _mealDietRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Diet> _dietBaseRepository;

        public GetDietMealsQueryHandler(IMealDietRepository mealDietRepository, IMapper mapper, IRepository<Domain.Entities.Diet> dietBaseRepository)
        {
            _mealDietRepository = mealDietRepository;
            _mapper = mapper;
            _dietBaseRepository = dietBaseRepository;
   
        }

        public async Task<List<MealDietMentorListResponse>> Handle(GetDietMealsQuery request, CancellationToken cancellationToken)
        {
            var diet = await _dietBaseRepository.GetByIdAsync(request.IdDiet, cancellationToken);
            if(diet == null || diet.IdDietician != request.IdDietician)
            {
                throw new NotFoundException("Diet not found");
            }
            var meals = await _mealDietRepository.GetMealsByDietIdAsync(request.IdDiet, cancellationToken);
            return _mapper.Map<List<MealDietMentorListResponse>>(meals);
        }
    }
}

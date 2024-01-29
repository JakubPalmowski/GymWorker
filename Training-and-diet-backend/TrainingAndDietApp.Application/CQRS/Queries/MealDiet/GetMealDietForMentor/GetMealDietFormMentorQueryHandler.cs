using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.CQRS.Responses.MealDiet;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetMealDietForMentor
{
    public class GetMealDietFormMentorQueryHandler : IRequestHandler<GetMealDietForMentorQuery, MealDietForMentorResponse>
    {
        private readonly IMealDietRepository _mealDietRepository;
        private readonly IRepository<Domain.Entities.Diet> _dietBaseRepository;
        private readonly IRepository<Domain.Entities.Meal> _mealBaseRepository;
        private readonly IMapper _mapper;

        public GetMealDietFormMentorQueryHandler(IMealDietRepository mealDietRepository, IRepository<Domain.Entities.Diet> dietBaseRepository, IRepository<Domain.Entities.Meal> mealBaseRepository, IMapper mapper)
        {
            _mealDietRepository = mealDietRepository;
            _dietBaseRepository = dietBaseRepository;
            _mealBaseRepository = mealBaseRepository;
            _mapper = mapper;

        }
        public async Task<MealDietForMentorResponse> Handle(GetMealDietForMentorQuery request, CancellationToken cancellationToken)
        {
            var mealDiet = await _mealDietRepository.GetMealDietByIdAsync(request.IdMealDiet, cancellationToken);
            if (mealDiet == null)
            {
                throw new NotFoundException("Meal diet not found");
            }
            var diet = await _dietBaseRepository.GetByIdAsync(mealDiet.IdDiet, cancellationToken);
            if (diet == null || diet.IdDietician != request.IdDietician)
            {
                throw new NotFoundException("Diet not found");
            }
            var meal = await _mealBaseRepository.GetByIdAsync(mealDiet.IdMeal, cancellationToken);
            if (meal == null || meal.IdDietician != request.IdDietician)
            {
                throw new NotFoundException("Meal not found");
            }
            return _mapper.Map<MealDietForMentorResponse>(mealDiet);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.MealDiet;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.MealDiet.GetMealDietForPupil
{
    public class GetMealDietForPupilQueryHandler : IRequestHandler<GetMealDietForPupilQuery, MealDietForPupilResponse>
    {
        private readonly IMealDietRepository _mealDietRepository;
        private readonly IRepository<Domain.Entities.Diet> _dietBaseRepository;
        private readonly IMapper _mapper;

        public GetMealDietForPupilQueryHandler(IMealDietRepository mealDietRepository, IRepository<Domain.Entities.Diet> dietBaseRepository, IMapper mapper)
        {
            _mealDietRepository = mealDietRepository;
            _dietBaseRepository = dietBaseRepository;
            _mapper = mapper;

        }
        public async Task<MealDietForPupilResponse> Handle(GetMealDietForPupilQuery request, CancellationToken cancellationToken)
        {
            var mealDiet = await _mealDietRepository.GetMealDietByIdAsync(request.IdMealDiet, cancellationToken);
            if (mealDiet == null)
            {
                throw new NotFoundException("Meal diet not found");
            }
            var diet = await _dietBaseRepository.GetByIdAsync(mealDiet.IdDiet, cancellationToken);
            if (diet == null || diet.IdPupil != request.IdPupil)
            {
                throw new NotFoundException("Diet not found");
            }
            return _mapper.Map<MealDietForPupilResponse>(mealDiet);

            
        }
    }
}

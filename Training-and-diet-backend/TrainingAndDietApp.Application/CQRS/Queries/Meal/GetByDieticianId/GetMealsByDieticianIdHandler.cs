using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Meal;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Meal.GetByDieticianId;

public class GetMealsByDieticianIdHandler : IRequestHandler<GetMealsByDieticianIdQuery, IEnumerable<MealResponse>>
{
    private readonly IMealRepository _repository;
    private readonly IMapper _mapper;

    public GetMealsByDieticianIdHandler(IMealRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MealResponse>> Handle(GetMealsByDieticianIdQuery request, CancellationToken cancellationToken)
    {
        var meals = await _repository.GetMealsByDieticianIdAsync(request.DieticianId, cancellationToken);
        return _mapper.Map<List<MealResponse>>(meals);
    }
}
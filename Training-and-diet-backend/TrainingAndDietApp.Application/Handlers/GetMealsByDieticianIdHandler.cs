using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries;
using TrainingAndDietApp.Application.Responses;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers;

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
        var meals = await _repository.GetMealsByDieticianIdAsync(request.DieticianId);
        return _mapper.Map<List<MealResponse>>(meals);
    }
}
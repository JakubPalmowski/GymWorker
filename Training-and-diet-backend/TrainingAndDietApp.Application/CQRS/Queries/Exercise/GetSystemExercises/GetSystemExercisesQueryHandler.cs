using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetAll;

public class GetSystemExercisesQueryHandler : IRequestHandler<GetSystemExercisesQuery, IEnumerable<ExerciseNameResponse>>
{
    private readonly IExerciseRepository _repository;
    private readonly IMapper _mapper;
    public GetSystemExercisesQueryHandler(IMapper mapper, IExerciseRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<IEnumerable<ExerciseNameResponse>> Handle(GetSystemExercisesQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _repository.GetSystemExercisesAsync(cancellationToken);
        if (exercises == null)
            throw new NotFoundException("Exercises not Found");

        return _mapper.Map<List<ExerciseNameResponse>>(exercises);

    }
}
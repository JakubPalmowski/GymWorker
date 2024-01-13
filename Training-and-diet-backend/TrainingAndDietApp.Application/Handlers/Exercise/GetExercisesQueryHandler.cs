using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise;

public class GetExercisesQueryHandler : IRequestHandler<GetExercisesQuery, IEnumerable<ExerciseNameResponse>>
{
    private readonly IRepository<Domain.Entities.Exercise> _repository;
    private readonly IMapper _mapper;
    public GetExercisesQueryHandler(IMapper mapper, IRepository<Domain.Entities.Exercise> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<IEnumerable<ExerciseNameResponse>> Handle(GetExercisesQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _repository.GetAllAsync(cancellationToken);
        if (exercises == null)
            throw new NotFoundException("Exercises not Found");

        return _mapper.Map<List<ExerciseNameResponse>>(exercises);

    }
}
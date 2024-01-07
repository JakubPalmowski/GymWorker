using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise;

public class GetExercisesQueryHandler : IRequestHandler<GetExercisesQuery, IEnumerable<ExerciseNameResponse>>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    public GetExercisesQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
    }
    public async Task<IEnumerable<ExerciseNameResponse>> Handle(GetExercisesQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _exerciseRepository.GetAllExercisesAsync(cancellationToken);
        if (exercises == null)
            throw new NotFoundException("Exercises not Found");

        return _mapper.Map<List<ExerciseNameResponse>>(exercises);

    }
}
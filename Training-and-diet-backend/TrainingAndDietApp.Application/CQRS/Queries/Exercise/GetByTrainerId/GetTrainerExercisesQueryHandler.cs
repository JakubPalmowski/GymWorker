using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainerId;

public class GetTrainerExercisesQueryHandler : IRequestHandler<GetTrainerExercisesQuery, IEnumerable<ExerciseNameResponse>>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    public GetTrainerExercisesQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
    }
    public async Task<IEnumerable<ExerciseNameResponse>> Handle(GetTrainerExercisesQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _exerciseRepository.GetTrainerExercisesAsync(request.LoggedUserId, cancellationToken);

        return exercises is null
            ? throw new NotFoundException("Exercises not found")
            : _mapper.Map<List<ExerciseNameResponse>>(exercises);
    }
}
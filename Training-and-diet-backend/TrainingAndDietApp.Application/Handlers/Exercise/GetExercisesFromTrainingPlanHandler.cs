using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise;

public class GetExercisesFromTrainingPlanHandler : IRequestHandler<GetExercisesFromTrainingPlanQuery, IEnumerable<ExerciseNameResponse>>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    public GetExercisesFromTrainingPlanHandler(IMapper mapper, IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
    }

    //nie rzuca exception tylko pusta liste
    public async Task<IEnumerable<ExerciseNameResponse>> Handle(GetExercisesFromTrainingPlanQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _exerciseRepository.GetExercisesFromTrainingPlanAsync(request.IdTrainingPlan, cancellationToken);

        if (exercises == null)
            throw new NotFoundException("Exercises not found");

        return _mapper.Map<List<ExerciseNameResponse>>(exercises);
    }
}
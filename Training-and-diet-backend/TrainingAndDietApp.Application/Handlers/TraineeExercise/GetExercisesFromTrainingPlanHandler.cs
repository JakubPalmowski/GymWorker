using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Application.Responses.TraineeExercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class GetExercisesFromTrainingPlanHandler : IRequestHandler<GetExercisesFromTrainingPlanQuery, IEnumerable<TraineeExerciseResponse>>
{
    private readonly ITraineeExercisesRepository _traineeExercisesRepository;
    private readonly IMapper _mapper;
    public GetExercisesFromTrainingPlanHandler(IMapper mapper, ITraineeExercisesRepository traineeExercisesRepository)
    {
        _mapper = mapper;
        _traineeExercisesRepository = traineeExercisesRepository;
    }

    

    public async Task<IEnumerable<TraineeExerciseResponse>> Handle(GetExercisesFromTrainingPlanQuery request, CancellationToken cancellationToken)
    {
        var traineeExercises = await _traineeExercisesRepository.GetExercisesFromTrainingPlanAsync(request.IdTrainingPlan, cancellationToken);
        if (!traineeExercises.Any())
            throw new NotFoundException("Exercises not found");

        return  _mapper.Map<List<TraineeExerciseResponse>>(traineeExercises);

    }
}
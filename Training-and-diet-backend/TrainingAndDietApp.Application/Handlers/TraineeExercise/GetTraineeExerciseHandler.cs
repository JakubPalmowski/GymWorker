using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.TraineeExercise;
using TrainingAndDietApp.Application.Responses.TraineeExercise;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class GetTraineeExerciseHandler : IRequestHandler<GetTraineeExerciseQuery, TraineeExerciseResponse>
{
    private readonly ITraineeExercisesRepository _traineeExercisesRepository;
    private readonly IMapper _mapper;

    public GetTraineeExerciseHandler(ITraineeExercisesRepository traineeExercisesRepository, IMapper mapper)
    {
        _traineeExercisesRepository = traineeExercisesRepository;
        _mapper = mapper;
    }
    public async Task<TraineeExerciseResponse> Handle(GetTraineeExerciseQuery request, CancellationToken cancellationToken)
    {
        var traineeExercise = await _traineeExercisesRepository.GetTraineeExerciseByIdAsync(request.IdTraineeExercise, cancellationToken);
        if (traineeExercise == null)
            throw new NotFoundException("TraineeExercise not found");

        return _mapper.Map<TraineeExerciseResponse>(traineeExercise);
    }
}
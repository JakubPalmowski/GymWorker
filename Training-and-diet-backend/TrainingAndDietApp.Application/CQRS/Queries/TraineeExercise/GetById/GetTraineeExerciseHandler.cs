using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById;

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
        var traineeExercise = await _traineeExercisesRepository.GetTraineeExerciseWithExerciseByIdAsync(request.IdTraineeExercise, cancellationToken);
        if (traineeExercise == null)
            throw new NotFoundException("TraineeExercise not found");

        return _mapper.Map<TraineeExerciseResponse>(traineeExercise);
    }
}
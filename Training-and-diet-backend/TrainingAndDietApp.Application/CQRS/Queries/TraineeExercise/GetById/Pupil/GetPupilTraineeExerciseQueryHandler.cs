using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById.Pupil;

public class GetPupilTraineeExerciseQueryHandler : IRequestHandler<GetPupilTraineeExerciseQuery, PupilTraineeExerciseResponse>
{
    private readonly ITraineeExercisesRepository _traineeExercisesRepository;
    private readonly IMapper _mapper;
    private readonly ITraineeExerciseAccessService _traineeExerciseAccessService;

    public GetPupilTraineeExerciseQueryHandler(ITraineeExercisesRepository traineeExercisesRepository, IMapper mapper, ITraineeExerciseAccessService traineeExerciseAccessService)
    {
        _traineeExercisesRepository = traineeExercisesRepository;
        _mapper = mapper;
        _traineeExerciseAccessService = traineeExerciseAccessService;
    }

    public async Task<PupilTraineeExerciseResponse> Handle(GetPupilTraineeExerciseQuery request, CancellationToken cancellationToken)
    {
        var traineeExercise = await _traineeExercisesRepository.GetPupilTraineeExerciseWithExerciseByIdAsync(request.IdTraineeExercise, request.LoggedUser, cancellationToken);
        if (traineeExercise == null)
            throw new NotFoundException("TraineeExercise not found");

        return _mapper.Map<PupilTraineeExerciseResponse>(traineeExercise);
    }
}


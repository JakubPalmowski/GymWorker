using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById.Trainer;

public class GetTraineeExerciseHandler : IRequestHandler<GetTrainerTraineeExerciseQuery, TrainerTraineeExerciseResponse>
{
    private readonly ITraineeExercisesRepository _traineeExercisesRepository;
    private readonly IMapper _mapper;
    private readonly ITraineeExerciseAccessService _traineeExerciseAccessService;

    public GetTraineeExerciseHandler(ITraineeExercisesRepository traineeExercisesRepository, IMapper mapper, ITraineeExerciseAccessService traineeExerciseAccessService)
    {
        _traineeExercisesRepository = traineeExercisesRepository;
        _mapper = mapper;
        _traineeExerciseAccessService = traineeExerciseAccessService;
    }
    public async Task<TrainerTraineeExerciseResponse> Handle(GetTrainerTraineeExerciseQuery request, CancellationToken cancellationToken)
    {
        var traineeExercise = await _traineeExercisesRepository.GetTraineeExerciseWithExerciseByIdAsync(request.IdTraineeExercise, cancellationToken);
        if (traineeExercise == null)
            throw new NotFoundException("TraineeExercise not found");
        var isAccessible = await _traineeExerciseAccessService.IsAccessibleByTrainer(request.IdTraineeExercise, request.LoggedUser, cancellationToken);
        if (!isAccessible)
            throw new ForbiddenException("You are not allowed to access this traineeExercise");

        return _mapper.Map<TrainerTraineeExerciseResponse>(traineeExercise);
    }
}
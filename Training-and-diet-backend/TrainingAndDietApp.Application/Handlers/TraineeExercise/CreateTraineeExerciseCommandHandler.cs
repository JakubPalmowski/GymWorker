using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class CreateTraineeExerciseCommandHandler : IRequestHandler<CreateTraineeExerciseCommand, CreateTraineeExerciseResponse>
{
    private readonly ITraineeExercisesRepository _traineeExercisesRepository;
    private readonly ITraineeExerciseService _exerciseService;
    private readonly IMapper _mapper;
    public CreateTraineeExerciseCommandHandler(IMapper mapper, ITraineeExercisesRepository traineeExercisesRepository, ITraineeExerciseService exerciseService)
    {
        _mapper = mapper;
        _traineeExercisesRepository = traineeExercisesRepository;
        _exerciseService = exerciseService;
    }
    public async Task<CreateTraineeExerciseResponse> Handle(CreateTraineeExerciseCommand request, CancellationToken cancellationToken)
    {
        if (!await _exerciseService.IsTrainingPlanValid(request.IdTrainingPlan))
            throw new NotFoundException("Training plan not found");

        if (!await _exerciseService.IsExerciseValid(request.IdExercise))
            throw new NotFoundException("Exercise not found");

        var traineeExercises = _mapper.Map<Domain.Entities.TraineeExercise>(request);

        await _traineeExercisesRepository.AddTraineeExercisesAsync(traineeExercises);

        int createdId = traineeExercises.IdExercise;

        return new CreateTraineeExerciseResponse{IdTraineeExercise = createdId};
    }
}
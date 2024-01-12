using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class DeleteTraineeExerciseCommandHandler : IRequestHandler<DeleteTraineeExerciseCommand>
{
    private readonly ITraineeExercisesRepository _traineeExercisesRepository;
    private readonly IMapper _mapper;

    public DeleteTraineeExerciseCommandHandler(ITraineeExercisesRepository traineeExercisesRepository, IMapper mapper)
    {
        _traineeExercisesRepository = traineeExercisesRepository;
        _mapper = mapper;
    }
    public async Task Handle(DeleteTraineeExerciseCommand request, CancellationToken cancellationToken)
    {
        var traineeExerciseToDelete = await _traineeExercisesRepository.GetTraineeExerciseByIdAsync(request.IdTraineeExercise, cancellationToken);
        if (traineeExerciseToDelete == null)
            throw new NotFoundException("TraineeExercise not found");
        await _traineeExercisesRepository.DeleteTraineeExerciseAsync(traineeExerciseToDelete.IdTraineeExercise, cancellationToken);
    }
}
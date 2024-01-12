using System.Collections.Generic;
using AutoMapper;
using MediatR;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class UpdateTraineeExerciseCommandHandler : IRequestHandler<UpdateTraineeExerciseInternalCommand>
{
    private readonly ITraineeExercisesRepository _repository;
    private readonly IMapper _mapper;

    public UpdateTraineeExerciseCommandHandler(ITraineeExercisesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task Handle(UpdateTraineeExerciseInternalCommand request, CancellationToken cancellationToken)
    {
        var traineeExerciseToUpdate = await _repository.GetTraineeExerciseByIdAsync(request.IdTraineeExercise, cancellationToken);
        if (traineeExerciseToUpdate == null)
            throw new NotFoundException("Meal not found");
        _mapper.Map(request, traineeExerciseToUpdate);
        await _repository.UpdateTraineeExerciseAsync(traineeExerciseToUpdate, cancellationToken);
    }
}
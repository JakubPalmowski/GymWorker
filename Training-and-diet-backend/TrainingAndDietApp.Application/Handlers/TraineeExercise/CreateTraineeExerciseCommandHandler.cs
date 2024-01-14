﻿using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class CreateTraineeExerciseCommandHandler : IRequestHandler<CreateTraineeExerciseCommand, CreateTraineeExerciseResponse>
{
    private readonly IRepository<Domain.Entities.TraineeExercise> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITraineeExerciseService _exerciseService;
    private readonly IMapper _mapper;
    public CreateTraineeExerciseCommandHandler(IMapper mapper, IRepository<Domain.Entities.TraineeExercise> repository, ITraineeExerciseService exerciseService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _exerciseService = exerciseService;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateTraineeExerciseResponse> Handle(CreateTraineeExerciseCommand request, CancellationToken cancellationToken)
    {
        if (!await _exerciseService.IsTrainingPlanValid(request.IdTrainingPlan))
            throw new NotFoundException("Training plan not found");

        if (!await _exerciseService.IsExerciseValid(request.IdExercise))
            throw new NotFoundException("Exercise not found");

        var traineeExercises = _mapper.Map<Domain.Entities.TraineeExercise>(request);

        await _repository.AddAsync(traineeExercises, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        int createdId = traineeExercises.IdExercise;

        return new CreateTraineeExerciseResponse{IdTraineeExercise = createdId};
    }
}
﻿using AutoMapper;
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

    public GetTraineeExerciseHandler(ITraineeExercisesRepository traineeExercisesRepository, IMapper mapper)
    {
        _traineeExercisesRepository = traineeExercisesRepository;
        _mapper = mapper;
    }
    public async Task<TrainerTraineeExerciseResponse> Handle(GetTrainerTraineeExerciseQuery request, CancellationToken cancellationToken)
    {
        var traineeExercise = await _traineeExercisesRepository.GetTrainerTraineeExerciseWithExerciseByIdAsync(request.IdTraineeExercise, request.LoggedUser, cancellationToken);
        return traineeExercise == null
            ? throw new NotFoundException("TraineeExercise not found")
            : _mapper.Map<TrainerTraineeExerciseResponse>(traineeExercise);
    }
}
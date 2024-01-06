using AutoMapper;
using MediatR;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise;

public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseInternalCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    public UpdateExerciseCommandHandler(IMapper mapper, IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
    }

    public async Task Handle(UpdateExerciseInternalCommand request, CancellationToken cancellationToken)
    {
        var exerciseToUpdate = await _exerciseRepository.GetExerciseByIdAsync(request.IdExercise, cancellationToken);
        if (exerciseToUpdate == null)
            throw new NotFoundException("Exercise not found");
        _mapper.Map(request, exerciseToUpdate);
        await _exerciseRepository.UpdateExerciseAsync(exerciseToUpdate, cancellationToken);
    }
}
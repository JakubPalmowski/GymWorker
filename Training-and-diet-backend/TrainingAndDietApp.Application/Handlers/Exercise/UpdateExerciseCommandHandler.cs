using AutoMapper;
using MediatR;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise;

public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseInternalCommand>
{
    private readonly IRepository<Domain.Entities.Exercise> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateExerciseCommandHandler(IMapper mapper, IRepository<Domain.Entities.Exercise> repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateExerciseInternalCommand request, CancellationToken cancellationToken)
    {
        var exerciseToUpdate = await _repository.GetByIdAsync(request.IdExercise, cancellationToken);
        if (exerciseToUpdate == null)
            throw new NotFoundException("Exercise not found");
        _mapper.Map(request, exerciseToUpdate);
        await _repository.UpdateAsync(exerciseToUpdate, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
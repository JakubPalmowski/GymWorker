using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Exercise.DeleteExercise;

public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand>
{
    private readonly IRepository<Domain.Entities.Exercise> _repository;
    private readonly IUnitOfWork _unitOfWork;


    public DeleteExerciseCommandHandler(IRepository<Domain.Entities.Exercise> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = await _repository.GetByIdAsync(request.IdExercise, cancellationToken);
        if (exercise == null)
            throw new NotFoundException("Exercise not found");

        await _repository.DeleteAsync(exercise.IdExercise, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
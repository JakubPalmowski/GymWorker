using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class DeleteTraineeExerciseCommandHandler : IRequestHandler<DeleteTraineeExerciseCommand>
{
    private readonly IRepository<Domain.Entities.TraineeExercise> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteTraineeExerciseCommandHandler(IRepository<Domain.Entities.TraineeExercise> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteTraineeExerciseCommand request, CancellationToken cancellationToken)
    {
        var traineeExerciseToDelete = await _repository.GetByIdAsync(request.IdTraineeExercise, cancellationToken);
        if (traineeExerciseToDelete == null)
            throw new NotFoundException("TraineeExercise not found");
        await _repository.DeleteAsync(traineeExerciseToDelete.IdTraineeExercise, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

    }
}
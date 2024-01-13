using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TraineeExercise;

public class UpdateTraineeExerciseCommandHandler : IRequestHandler<UpdateTraineeExerciseInternalCommand>
{
    private readonly IRepository<Domain.Entities.TraineeExercise> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTraineeExerciseCommandHandler(IRepository<Domain.Entities.TraineeExercise> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateTraineeExerciseInternalCommand request, CancellationToken cancellationToken)
    {
        var traineeExerciseToUpdate = await _repository.GetByIdAsync(request.IdTraineeExercise, cancellationToken);
        if (traineeExerciseToUpdate == null)
            throw new NotFoundException("Meal not found");
        _mapper.Map(request, traineeExerciseToUpdate);
        await _repository.UpdateAsync(traineeExerciseToUpdate, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
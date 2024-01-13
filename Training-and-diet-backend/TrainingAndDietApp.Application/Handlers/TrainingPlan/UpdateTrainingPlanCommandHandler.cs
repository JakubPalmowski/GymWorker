using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TrainingPlan;

public class UpdateTrainingPlanCommandHandler : IRequestHandler<UpdateTrainingPlanInternalCommand>
{
    private readonly IRepository<Domain.Entities.TrainingPlan> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateTrainingPlanCommandHandler(IMapper mapper, IRepository<Domain.Entities.TrainingPlan> repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateTrainingPlanInternalCommand request, CancellationToken cancellationToken)
    {
        var trainingPlan = await _repository.GetByIdAsync(request.IdTrainingPlan, cancellationToken);
        if (trainingPlan == null)
            throw new NotFoundException("Training plan not found");

        _mapper.Map(request, trainingPlan);
        await _repository.UpdateAsync(trainingPlan, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
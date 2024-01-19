using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.AssignPupil;

public class AssignPupilToTrainingPlanCommandHandler : IRequestHandler<AssignPupilToTrainingPlanInternalCommand>
{
    private readonly IRepository<Domain.Entities.TrainingPlan> _repository;
    private readonly IRepository<Domain.Entities.User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignPupilToTrainingPlanCommandHandler(IRepository<Domain.Entities.TrainingPlan> repository, IUnitOfWork unitOfWork, IRepository<Domain.Entities.User> userRepository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task Handle(AssignPupilToTrainingPlanInternalCommand request, CancellationToken cancellationToken)
    {
       var trainingPlan = await _repository.GetByIdAsync(request.IdTrainingPlan, cancellationToken);
       if (trainingPlan is null)
           throw new NotFoundException("Training Plan does not exists");

       var pupil = await _userRepository.GetByIdAsync(request.AssignPupilToTrainingPlanCommand.IdPupil, cancellationToken);

       if (pupil is null)
           throw new NotFoundException("Pupil does not exists");

       if (pupil.IdRole != 2)
           throw new BadRequestException("User is not a pupil");

       trainingPlan.IdPupil = request.AssignPupilToTrainingPlanCommand.IdPupil;
       trainingPlan.IdTrainer = request.IdTrainer;
       await _repository.UpdateAsync(trainingPlan, cancellationToken);
       await _unitOfWork.CommitAsync(cancellationToken);
    }
}
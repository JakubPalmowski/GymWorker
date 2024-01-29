using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Assign
{
    public class AssignPupilToDietCommandHandler : IRequestHandler<AssignPupilToDietInternalCommand>
    {
        private readonly IRepository<Diet> _dietBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Domain.Entities.User> _userBaseRepository;

        public AssignPupilToDietCommandHandler(IRepository<Domain.Entities.Diet> dietBaseRepository, IUnitOfWork unitOfWork, IRepository<Domain.Entities.User> userBaseRepository)
        {
            _dietBaseRepository = dietBaseRepository;
            _unitOfWork = unitOfWork;
            _userBaseRepository = userBaseRepository;
        }
        public async Task Handle(AssignPupilToDietInternalCommand request, CancellationToken cancellationToken)
        {
            var diet = await _dietBaseRepository.GetByIdAsync(request.IdDiet, cancellationToken);
            if (diet is null)
                throw new NotFoundException("Diet does not exists");

            if (diet.IdDietician != request.IdDietician)
                throw new BadRequestException("Dietician is not owner of this diet");
                
            var pupil = await _userBaseRepository.GetByIdAsync(request.AssignPupilToDietCommand.IdPupil, cancellationToken);

            if (pupil is null)
                throw new NotFoundException("Pupil does not exists");

            if (pupil.IdRole != 2)
                throw new BadRequestException("User is not a pupil");

            diet.IdPupil = request.AssignPupilToDietCommand.IdPupil;
            await _dietBaseRepository.UpdateAsync(diet, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
                }
    }
}

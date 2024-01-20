using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteGym
{
    public class DeleteGymCommandHandler : IRequestHandler<DeleteGymCommand>
    {
        private readonly IRepository<Domain.Entities.Gym> _gymBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGymRepository _gymRepository;
        private readonly IRepository<Address> _addressBaseRepository;

        public DeleteGymCommandHandler(IRepository<Address> addressBaseRepository,IGymRepository gymRepository,IRepository<Domain.Entities.Gym> gymBaseRepository, IUnitOfWork unitOfWork)
        {
            _gymBaseRepository = gymBaseRepository;
            _unitOfWork = unitOfWork;
            _gymRepository = gymRepository;
            _addressBaseRepository = addressBaseRepository;
        }
        public async Task Handle(DeleteGymCommand request, CancellationToken cancellationToken)
        {
            var gym = await _gymRepository.GetGymWithAddressByIdAsync(request.idGym, cancellationToken);
            if (gym == null)
            {
                throw new NotFoundException("Nie znaleziono siłowni");
            }
            if(!gym.Address.Gyms.Where(g => g.IdGym != gym.IdGym).Any())
            {
                await _addressBaseRepository.DeleteAsync(gym.Address.IdAddress, cancellationToken);
            }
            await _gymBaseRepository.DeleteAsync(gym.IdGym, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

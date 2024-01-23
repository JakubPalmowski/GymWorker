using MediatR;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Abstractions;


namespace TrainingAndDietApp.Application.CQRS.Commands.Gym.Create
{
    public class CreateGymCommandHandler : IRequestHandler<CreateGymInternalCommand>
    {
        private readonly IRepository<Domain.Entities.Gym> _gymBaseRepository;
        private readonly IRepository<Address> _addressBaseRepository;
        private readonly IRepository<TrainerGym> _trainerGymBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressRepository _addressRepository;

        public CreateGymCommandHandler(IRepository<Domain.Entities.Gym> gymBaseRepository, IRepository<Address> addressBaseRepository, IRepository<TrainerGym>  trainerGymBaseRepository, IAddressRepository addressRepository, IUnitOfWork unitOfWork)
        {
            _gymBaseRepository = gymBaseRepository;
            _addressBaseRepository = addressBaseRepository;
            _trainerGymBaseRepository = trainerGymBaseRepository;
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateGymInternalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Rozpoczęcie transakcji
                _unitOfWork.BeginTransaction();

                var address = await _addressRepository.CheckIfAddressExistsAsync(request.GymCommand.City, request.GymCommand.Street, request.GymCommand.PostalCode, cancellationToken);
                if (address == null)
                {
                    address = new Address
                    {
                        City = request.GymCommand.City,
                        Street = request.GymCommand.Street,
                        PostalCode = request.GymCommand.PostalCode
                    };
                    await _addressBaseRepository.AddAsync(address, cancellationToken);
                    await _unitOfWork.CommitAsync(cancellationToken);
                }

                var gym = new Domain.Entities.Gym
                {
                    Name = request.GymCommand.Name,
                    AddedBy = request.IdUser,
                    IdAddress = address.IdAddress,
                    Status = Domain.Enums.Status.Pending
                };
                await _gymBaseRepository.AddAsync(gym, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                var trainerGym = new TrainerGym
                {
                    IdGym = gym.IdGym,
                    IdTrainer = request.IdUser
                };
                await _trainerGymBaseRepository.AddAsync(trainerGym, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw new Exception("Nie udało się wykonać operacji.");
            }
        }

    }
}


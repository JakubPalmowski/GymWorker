using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Training_and_diet_backend.Data.Migrations;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;


namespace TrainingAndDietApp.Application.CQRS.Commands.Gym.Create
{
    public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand>
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
        public async Task Handle(CreateGymCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Rozpoczęcie transakcji
                _unitOfWork.BeginTransaction();

                var address = await _addressRepository.CheckIfAddressExistsAsync(request.City, request.Street, request.PostalCode, cancellationToken);
                if (address == null)
                {
                    address = new Address
                    {
                        City = request.City,
                        Street = request.Street,
                        PostalCode = request.PostalCode
                    };
                    await _addressBaseRepository.AddAsync(address, cancellationToken);
                    await _unitOfWork.CommitAsync(cancellationToken);
                }

                var gym = new Domain.Entities.Gym
                {
                    Name = request.Name,
                    AddedBy = request.AddedBy,
                    IdAddress = address.IdAddress,
                    Status = Domain.Enums.Status.Pending
                };
                await _gymBaseRepository.AddAsync(gym, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                var trainerGym = new TrainerGym
                {
                    IdGym = gym.IdGym,
                    IdTrainer = request.AddedBy
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


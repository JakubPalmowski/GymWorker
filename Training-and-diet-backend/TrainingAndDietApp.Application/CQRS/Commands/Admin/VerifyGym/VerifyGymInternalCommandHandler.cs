using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyGym
{
    public class VerifyGymInternalCommandHandler : IRequestHandler<VerifyGymInternalCommand>
    {

         private readonly IGymRepository _gymRepository;
        private readonly IRepository<Address> _addressBaseRepository;
        private readonly IRepository<Domain.Entities.Gym> _gymBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressRepository _addressRepository;

        public VerifyGymInternalCommandHandler(IAddressRepository addressRepository,IGymRepository gymRepository, IRepository<Address> addressBaseRepository, IRepository<Domain.Entities.Gym> gymBaseRepository, IUnitOfWork unitOfWork)
        {
            _gymRepository = gymRepository;
            _addressBaseRepository = addressBaseRepository;
            _gymBaseRepository = gymBaseRepository;
            _unitOfWork = unitOfWork;
            _addressRepository = addressRepository;
        }
        public async Task Handle(VerifyGymInternalCommand request, CancellationToken cancellationToken)
        {
            try{
            _unitOfWork.BeginTransaction();
            var gym = await _gymRepository.GetGymWithAddressByIdAsync(request.IdGym, cancellationToken);
            if (gym == null)
            {
                throw new NotFoundException("");
            }
            if(gym.Status == Domain.Enums.Status.Active){
                throw new BadRequestException("");
            }
             var address = gym.Address;
            if(!gym.Address.Gyms.Where(g => g.IdGym != gym.IdGym).Any()){
                gym.Address.City = request.GymCommand.City;
                gym.Address.Street = request.GymCommand.Street;
                gym.Address.PostalCode = request.GymCommand.PostalCode;
                await _addressBaseRepository.UpdateAsync(address, cancellationToken);
            }else{
                var updatedAddress = await _addressRepository.CheckIfAddressExistsAsync(request.GymCommand.City, request.GymCommand.Street, request.GymCommand.PostalCode, cancellationToken);
                if(updatedAddress != null){
                    gym.IdAddress = updatedAddress.IdAddress;
                }else{
                var newAddress = new Address
                {
                    City = request.GymCommand.City,
                    Street = request.GymCommand.Street,
                    PostalCode = request.GymCommand.PostalCode
                };
                await _addressBaseRepository.AddAsync(newAddress, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);
                gym.IdAddress = newAddress.IdAddress;
                }
            }
            gym.Name = request.GymCommand.Name;
            gym.Status = Domain.Enums.Status.Active;
            await _gymBaseRepository.UpdateAsync(gym, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }catch(Exception e){
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            if(e is BadRequestException){
                throw new BadRequestException("Nie można weryfikować aktywnej siłowni.");
            }else if(e is NotFoundException){
                throw new NotFoundException("Nie znaleziono siłowni");
            }else{
                throw new Exception("Nie udało się wykonać operacji.");
            }
                
        }
           
        }
    }
}

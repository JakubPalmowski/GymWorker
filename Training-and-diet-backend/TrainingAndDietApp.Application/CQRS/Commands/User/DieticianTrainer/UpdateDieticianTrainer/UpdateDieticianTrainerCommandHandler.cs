using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Responses.Gym;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.DieticianTrainer.UpdateDieticianTrainer
{
    public class UpdateDieticianTrainerCommandHandler : IRequestHandler<UpdateDieticianTrainerInternalCommand>
    {
         private readonly ITrainerGymRepository _trainerGymRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IGymRepository _gymRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdateDieticianTrainerCommandHandler(ITrainerGymRepository trainerGymRepository, IUserRepository userRepository, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork, IGymRepository gymRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _gymRepository = gymRepository;
            _trainerGymRepository = trainerGymRepository;
        }
        //refactor
        public async Task Handle(UpdateDieticianTrainerInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserWithDetailsAsync(request.IdUser, cancellationToken);
            if (userToUpdate == null)
            {
                throw new NotFoundException("User not found");
            }
            var dieticianTrainerRole = await _userService.CheckIfUserIsDieticianTrainer(request.IdUser, cancellationToken);
            if (!dieticianTrainerRole)
            {
                throw new BadRequestException("User is not a dietician-trainer");
            }
            userToUpdate.Name = request.DieticianTrainerCommand.Name;
            userToUpdate.LastName = request.DieticianTrainerCommand.LastName;
            if (request.DieticianTrainerCommand.Email != userToUpdate.Email)
            {
                userToUpdate.Email = request.DieticianTrainerCommand.Email;
                userToUpdate.EmailConfirmationToken = null;
            }
            var trainerGyms = await _gymRepository.GetMentorActiveGymsAsync(request.IdUser, cancellationToken);
            var newGyms = _mapper.Map<List<ActiveGymResponse>>(request.DieticianTrainerCommand.TrainerGyms);
            var existingGymIds = trainerGyms.Select(g => g.IdGym).ToList();
            var newGymIds = newGyms.Select(g => g.IdGym).ToList();
            var addedGyms = newGymIds.Except(existingGymIds).ToList();
            var removedGyms = existingGymIds.Except(newGymIds).ToList();
            
            foreach (var gymId in addedGyms)
            {
                if (await _gymRepository.GetByIdAsync(gymId, cancellationToken) == null)
                {
                    throw new NotFoundException("Gym not found");
                }

                var trainerGym = new TrainerGym
                {
                    IdGym = gymId,
                    IdTrainer = request.IdUser
                };
                await _trainerGymRepository.AddAsync(trainerGym, cancellationToken);
            }
            foreach (var gymId in removedGyms)
            {
                if (await _gymRepository.GetByIdAsync(gymId, cancellationToken) == null)
                {
                    throw new NotFoundException("Gym not found");
                }
                
                var trainerGym = await _trainerGymRepository.GetByIdAsync(request.IdUser, gymId, cancellationToken);
                if(trainerGym == null){
                    throw new BadRequestException("User is not a trainer in this gym");
                }
                await _trainerGymRepository.DeleteAsync(trainerGym, cancellationToken);
            }
            userToUpdate.PhoneNumber = request.DieticianTrainerCommand.PhoneNumber;
            userToUpdate.DietPriceFrom = request.DieticianTrainerCommand.DietPriceFrom;
            userToUpdate.DietPriceTo = request.DieticianTrainerCommand.DietPriceTo;
            userToUpdate.TrainingPlanPriceFrom = request.DieticianTrainerCommand.TrainingPlanPriceFrom;
            userToUpdate.TrainingPlanPriceTo = request.DieticianTrainerCommand.TrainingPlanPriceTo;
            userToUpdate.PersonalTrainingPriceFrom = request.DieticianTrainerCommand.PersonalTrainingPriceFrom;
            userToUpdate.PersonalTrainingPriceTo = request.DieticianTrainerCommand.PersonalTrainingPriceTo;
            userToUpdate.Bio = request.DieticianTrainerCommand.Bio;

            await _userRepository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}
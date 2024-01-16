using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.User.Pupil;
using TrainingAndDietApp.Application.Commands.User.Trainer;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Responses.Gym;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.Handlers.User.Pupil
{
    public class UpdateTrainerCommandHandler : IRequestHandler<UpdateTrainerInternalCommand>
    {
        private readonly ITrainerGymRepository _trainerGymRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IGymRepository _gymRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdateTrainerCommandHandler(ITrainerGymRepository trainerGymRepository, IUserRepository userRepository, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork, IGymRepository gymRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _gymRepository = gymRepository;
            _trainerGymRepository = trainerGymRepository;
        }
        public async Task Handle(UpdateTrainerInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserWithDetailsAsync(request.IdUser, cancellationToken);
            if (userToUpdate == null)
            {
                throw new NotFoundException("User not found");
            }
            var trainerRole = await _userService.CheckIfUserIsTrainer(request.IdUser, cancellationToken);
            if (!trainerRole)
            {
                throw new BadRequestException("User is not a trainer");
            }
            var trainerGyms = await _gymRepository.GetMentorActiveGymsAsync(request.IdUser, cancellationToken);
            var newGyms = _mapper.Map<List<ActiveGymResponse>>(request.TrainerCommand.TrainerGyms);
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

                if(await _trainerGymRepository.GetByIdAsync(request.IdUser, gymId, cancellationToken) == null){
                    throw new BadRequestException("User is not a trainer in this gym");
                }
                var trainerGym = new TrainerGym
                {
                    IdGym = gymId,
                    IdTrainer = request.IdUser
                };
                await _trainerGymRepository.DeleteAsync(trainerGym, cancellationToken);
            }
           

            userToUpdate.Name = request.TrainerCommand.Name;
            userToUpdate.LastName = request.TrainerCommand.LastName;
            if (request.TrainerCommand.Email != userToUpdate.Email)
            {
                userToUpdate.Email = request.TrainerCommand.Email;
                userToUpdate.EmailValidated = false;
            }
            userToUpdate.PhoneNumber = request.TrainerCommand.PhoneNumber;
            userToUpdate.TrainingPlanPriceFrom = request.TrainerCommand.TrainingPlanPriceFrom;
            userToUpdate.TrainingPlanPriceTo = request.TrainerCommand.TrainingPlanPriceTo;
            userToUpdate.PersonalTrainingPriceFrom = request.TrainerCommand.PersonalTrainingPriceFrom;
            userToUpdate.PersonalTrainingPriceTo = request.TrainerCommand.PersonalTrainingPriceTo;
            userToUpdate.Bio = request.TrainerCommand.Bio;
            

            await _userRepository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

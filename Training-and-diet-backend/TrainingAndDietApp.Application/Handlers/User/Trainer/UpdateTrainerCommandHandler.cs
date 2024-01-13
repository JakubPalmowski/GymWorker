using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.User.Pupil;
using TrainingAndDietApp.Application.Commands.User.Trainer;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Pupil
{
    public class UpdateTrainerCommandHandler : IRequestHandler<UpdateTrainerInternalCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdateTrainerCommandHandler(IUserRepository userRepository, IUserService userService, IMapper mapper)
        {
            _userRepository = userRepository;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task Handle(UpdateTrainerInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserByIdAsync(request.IdUser, cancellationToken);
            if (userToUpdate == null)
            {
                throw new NotFoundException("User not found");
            }
            var trainerRole = await _userService.CheckIfUserIsTrainer(request.IdUser, cancellationToken);
            if (!trainerRole)
            {
                throw new BadRequestException("User is not a trainer");
            }
            userToUpdate.Name = request.TrainerCommand.Name;
            userToUpdate.LastName = request.TrainerCommand.LastName;
            if (!(request.TrainerCommand.Email == userToUpdate.Email))
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

            await _userRepository.UpdateUserAsync(userToUpdate, cancellationToken);
        }
    }
}

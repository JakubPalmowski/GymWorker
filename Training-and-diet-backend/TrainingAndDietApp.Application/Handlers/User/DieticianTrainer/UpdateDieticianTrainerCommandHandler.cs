using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.User.Dietician;
using TrainingAndDietApp.Application.Commands.User.DieticianTrainer;
using TrainingAndDietApp.Application.Commands.User.Pupil;
using TrainingAndDietApp.Application.Commands.User.Trainer;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Pupil
{
    public class UpdateDieticianTrainerCommandHandler : IRequestHandler<UpdateDieticianTrainerInternalCommand>
    {
        private readonly IRepository<Domain.Entities.User> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdateDieticianTrainerCommandHandler(IRepository<Domain.Entities.User> baseRepository,IUserRepository userRepository, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork)
        {
             _baseRepository = baseRepository;
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
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
                userToUpdate.EmailValidated = false;
            }
            userToUpdate.PhoneNumber = request.DieticianTrainerCommand.PhoneNumber;
            userToUpdate.DietPriceFrom = request.DieticianTrainerCommand.DietPriceFrom;
            userToUpdate.DietPriceTo = request.DieticianTrainerCommand.DietPriceTo;
            userToUpdate.TrainingPlanPriceFrom = request.DieticianTrainerCommand.TrainingPlanPriceFrom;
            userToUpdate.TrainingPlanPriceTo = request.DieticianTrainerCommand.TrainingPlanPriceTo;
            userToUpdate.PersonalTrainingPriceFrom = request.DieticianTrainerCommand.PersonalTrainingPriceFrom;
            userToUpdate.PersonalTrainingPriceTo = request.DieticianTrainerCommand.PersonalTrainingPriceTo;
            userToUpdate.Bio = request.DieticianTrainerCommand.Bio;

            await _baseRepository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}
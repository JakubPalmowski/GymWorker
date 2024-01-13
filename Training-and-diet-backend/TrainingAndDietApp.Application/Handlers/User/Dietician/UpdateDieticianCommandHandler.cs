using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.User.Dietician;
using TrainingAndDietApp.Application.Commands.User.Pupil;
using TrainingAndDietApp.Application.Commands.User.Trainer;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Pupil
{
    public class UpdateDieticianCommandHandler : IRequestHandler<UpdateDieticianInternalCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdateDieticianCommandHandler(IUserRepository userRepository, IUserService userService, IMapper mapper)
        {
            _userRepository = userRepository;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task Handle(UpdateDieticianInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserByIdAsync(request.IdUser, cancellationToken);
            if (userToUpdate == null)
            {
                throw new NotFoundException("User not found");
            }
            var dieticianRole = await _userService.CheckIfUserIsDietician(request.IdUser, cancellationToken);
            if (!dieticianRole)
            {
                throw new BadRequestException("User is not a dietician");
            }
            userToUpdate.Name = request.DieticianCommand.Name;
            userToUpdate.LastName = request.DieticianCommand.LastName;
            if (request.DieticianCommand.Email != userToUpdate.Email)
            {
                userToUpdate.Email = request.DieticianCommand.Email;
                userToUpdate.EmailValidated = false;
            }
            userToUpdate.PhoneNumber = request.DieticianCommand.PhoneNumber;
            userToUpdate.DietPriceFrom = request.DieticianCommand.DietPriceFrom;
            userToUpdate.DietPriceTo = request.DieticianCommand.DietPriceTo;
            userToUpdate.Bio = request.DieticianCommand.Bio;

            await _userRepository.UpdateUserAsync(userToUpdate, cancellationToken);
        }
    }
}
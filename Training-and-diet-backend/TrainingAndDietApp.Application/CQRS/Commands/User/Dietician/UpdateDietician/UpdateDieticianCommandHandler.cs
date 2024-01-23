using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Dietician.UpdateDietician
{
    public class UpdateDieticianCommandHandler : IRequestHandler<UpdateDieticianInternalCommand>
    {
        private readonly IRepository<Domain.Entities.User> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateDieticianCommandHandler(IRepository<Domain.Entities.User> baseRepository,IUserRepository userRepository, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        //refactor bez maila
        public async Task Handle(UpdateDieticianInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserWithDetailsAsync(request.IdUser, cancellationToken);
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
                userToUpdate.EmailConfirmationToken = null;
            }
            userToUpdate.PhoneNumber = request.DieticianCommand.PhoneNumber;
            userToUpdate.DietPriceFrom = request.DieticianCommand.DietPriceFrom;
            userToUpdate.DietPriceTo = request.DieticianCommand.DietPriceTo;
            userToUpdate.Bio = request.DieticianCommand.Bio;

            await _baseRepository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
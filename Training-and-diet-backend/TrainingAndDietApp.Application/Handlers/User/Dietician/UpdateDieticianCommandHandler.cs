using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.User.Dietician;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Dietician
{
    public class UpdateDieticianCommandHandler : IRequestHandler<UpdateDieticianInternalCommand>
    {
        private readonly IRepository<Domain.Entities.User> _repository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateDieticianCommandHandler(IUserService userService, IMapper mapper, IRepository<Domain.Entities.User> repository, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        //refactor
        public async Task Handle(UpdateDieticianInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _repository.GetByIdAsync(request.IdUser, cancellationToken);
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

            await _repository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
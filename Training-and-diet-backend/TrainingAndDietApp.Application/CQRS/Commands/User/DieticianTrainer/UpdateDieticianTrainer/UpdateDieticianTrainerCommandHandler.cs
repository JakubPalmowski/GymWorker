using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.DieticianTrainer.UpdateDieticianTrainer
{
    public class UpdateDieticianTrainerCommandHandler : IRequestHandler<UpdateDieticianTrainerInternalCommand>
    {
        private readonly IRepository<Domain.Entities.User> _repository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateDieticianTrainerCommandHandler(IRepository<Domain.Entities.User> repository, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        //refactor
        public async Task Handle(UpdateDieticianTrainerInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _repository.GetByIdAsync(request.IdUser, cancellationToken);
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
            userToUpdate.PhoneNumber = request.DieticianTrainerCommand.PhoneNumber;
            userToUpdate.DietPriceFrom = request.DieticianTrainerCommand.DietPriceFrom;
            userToUpdate.DietPriceTo = request.DieticianTrainerCommand.DietPriceTo;
            userToUpdate.TrainingPlanPriceFrom = request.DieticianTrainerCommand.TrainingPlanPriceFrom;
            userToUpdate.TrainingPlanPriceTo = request.DieticianTrainerCommand.TrainingPlanPriceTo;
            userToUpdate.PersonalTrainingPriceFrom = request.DieticianTrainerCommand.PersonalTrainingPriceFrom;
            userToUpdate.PersonalTrainingPriceTo = request.DieticianTrainerCommand.PersonalTrainingPriceTo;
            userToUpdate.Bio = request.DieticianTrainerCommand.Bio;

            await _repository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}
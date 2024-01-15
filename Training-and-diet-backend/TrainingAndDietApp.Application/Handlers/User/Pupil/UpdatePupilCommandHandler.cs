using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.User.Pupil;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Pupil
{
    public class UpdatePupilCommandHandler : IRequestHandler<UpdatePupilInternalCommand>
    {
        private readonly IRepository<Domain.Entities.User> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdatePupilCommandHandler(IRepository<Domain.Entities.User> repository, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdatePupilInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _repository.GetByIdAsync(request.IdUser, cancellationToken);
            if (userToUpdate==null){
                throw new NotFoundException("User not found");
            }
            var pupilRole = await _userService.CheckIfUserIsPupil(request.IdUser, cancellationToken);
            if (!pupilRole)
            {
                throw new BadRequestException("User is not a pupil");
            }
            userToUpdate.Name = request.PupilCommand.Name;
            userToUpdate.LastName = request.PupilCommand.LastName;
            if(!(request.PupilCommand.Email == userToUpdate.Email)){
                userToUpdate.Email = request.PupilCommand.Email;
                userToUpdate.EmailConfirmationToken = null;
            }
            userToUpdate.PhoneNumber = request.PupilCommand.PhoneNumber;
            userToUpdate.Weight = request.PupilCommand.Weight;
            userToUpdate.Height = request.PupilCommand.Height;
            userToUpdate.DateOfBirth = request.PupilCommand.DateOfBirth;
            userToUpdate.Sex = request.PupilCommand.Sex;
            userToUpdate.Bio = request.PupilCommand.Bio;
            
            await _repository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}

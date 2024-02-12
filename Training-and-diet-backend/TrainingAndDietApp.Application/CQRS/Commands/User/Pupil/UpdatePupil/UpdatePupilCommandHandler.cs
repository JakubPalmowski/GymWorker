using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Pupil.UpdatePupil
{
    public class UpdatePupilCommandHandler : IRequestHandler<UpdatePupilInternalCommand>
    {
        private readonly IRepository<Domain.Entities.User> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdatePupilCommandHandler(IRepository<Domain.Entities.User> baseRepository,IUserRepository userRepository, IUserService userService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task Handle(UpdatePupilInternalCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserWithDetailsAsync(request.IdUser, cancellationToken);
            if (userToUpdate==null)
                throw new NotFoundException("User not found");
            
            var pupilRole = await _userService.CheckIfUserIsPupil(request.IdUser, cancellationToken);
            if (!pupilRole)
                throw new BadRequestException("User is not a pupil");
            
            userToUpdate.Name = request.PupilCommand.Name;
            userToUpdate.LastName = request.PupilCommand.LastName;
            userToUpdate.Email = request.PupilCommand.Email;

            userToUpdate.Weight = request.PupilCommand.Weight;
            userToUpdate.Height = request.PupilCommand.Height;
            userToUpdate.DateOfBirth = request.PupilCommand.DateOfBirth;
            userToUpdate.Sex = request.PupilCommand.Sex;
            userToUpdate.Bio = request.PupilCommand.Bio;
            
            await _baseRepository.UpdateAsync(userToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}

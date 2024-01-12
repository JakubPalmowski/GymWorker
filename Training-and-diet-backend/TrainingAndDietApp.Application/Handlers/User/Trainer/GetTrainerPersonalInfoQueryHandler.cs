using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses.Trainer;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Trainer
{
    public class GetTrainerPersonalInfoQueryHandler : IRequestHandler<GetTrainerPersonalInfoQuery, TrainerPersonalInfoResponse>{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

        public GetTrainerPersonalInfoQueryHandler(IMapper mapper, IUserRepository userRepository, IUserService userService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userService = userService;
    }
        public async Task<TrainerPersonalInfoResponse> Handle(GetTrainerPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var trainer = await _userRepository.GetUserByIdAsync(request.id, cancellationToken);
            if (trainer == null)
                throw new NotFoundException("Trainer not found");
            var role = await _userService.CheckIfUserIsTrainer(request.id, cancellationToken);
            if(!role)
                throw new BadRequestException("User is not a trainer");
            
            var trainerResponse = _mapper.Map<TrainerPersonalInfoResponse>(trainer);
            return trainerResponse;
        }
    
}
}

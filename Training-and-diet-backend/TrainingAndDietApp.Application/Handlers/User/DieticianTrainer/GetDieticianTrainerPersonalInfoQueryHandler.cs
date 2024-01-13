using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.DieticianTrainer
{
    public class GetDieticianTrainerPersonalInfoQueryHandler : IRequestHandler<GetDieticianTrainerPersonalInfoQuery, DieticianTrainerPersonalInfoResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetDieticianTrainerPersonalInfoQueryHandler(IUserRepository userRepository, IMapper mapper, IUserService userService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<DieticianTrainerPersonalInfoResponse> Handle(GetDieticianTrainerPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var dieticianTrainer = await _userRepository.GetUserByIdAsync(request.id, cancellationToken);
            if (dieticianTrainer == null)
                throw new NotFoundException("User not found");
            var role = await _userService.CheckIfUserIsDieticianTrainer(request.id, cancellationToken);
            if(!role)
                throw new BadRequestException("User is not a dietician-trainer");
            
            var dieticianTrainerResponse = _mapper.Map<DieticianTrainerPersonalInfoResponse>(dieticianTrainer);
            return dieticianTrainerResponse;
        }
    }
}

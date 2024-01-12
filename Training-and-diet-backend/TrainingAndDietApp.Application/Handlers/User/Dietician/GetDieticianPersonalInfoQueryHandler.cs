using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses.Dietician;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Dietician
{
    public class GetDieticianPersonalInfoQueryHandler : IRequestHandler<GetDieticianPersonalInfoQuery, DieticianPersonalInfoResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetDieticianPersonalInfoQueryHandler(IUserRepository userRepository, IMapper mapper, IUserService userService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<DieticianPersonalInfoResponse> Handle(GetDieticianPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var dietician = await _userRepository.GetUserByIdAsync(request.id, cancellationToken);
            if (dietician == null)
                throw new NotFoundException("Dietician not found");
            var role = await _userService.CheckIfUserIsDietician(request.id, cancellationToken);
            if(!role)
                throw new BadRequestException("User is not a pupil");
            
            var dietcianResponse = _mapper.Map<DieticianPersonalInfoResponse>(dietician);
            return dietcianResponse;
        }
    }
}

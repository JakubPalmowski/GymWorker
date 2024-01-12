using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses.Pupil;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Pupil
{
    public class GetPupilPersonalInfoQueryHandler : IRequestHandler<GetPupilPersonalInfoQuery, PupilPersonalInfoResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetPupilPersonalInfoQueryHandler(IUserRepository userRepository, IMapper mapper, IUserService userService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<PupilPersonalInfoResponse> Handle(GetPupilPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var pupil = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);
            if (pupil == null)
                throw new NotFoundException("Pupil not found");
            var role = await _userService.CheckIfUserIsPupil(request.Id, cancellationToken);
            if(!role)
                throw new BadRequestException("User is not a pupil");
            
            var pupilResponse = _mapper.Map<PupilPersonalInfoResponse>(pupil);
            return pupilResponse;
        }
    }
}
   


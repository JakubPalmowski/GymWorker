using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses.Pupil;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User
{
    public class GetPupilPersonalInfoQueryHandler : IRequestHandler<GetPupilPersonalInfoQuery, PupilPersonalInfoResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetPupilPersonalInfoQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<PupilPersonalInfoResponse> Handle(GetPupilPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var pupil = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);
            if (pupil == null)
                throw new NotFoundException("Pupil not found");
            
            var pupilResponse = _mapper.Map<PupilPersonalInfoResponse>(pupil);
            return pupilResponse;
        }
    }
}
   


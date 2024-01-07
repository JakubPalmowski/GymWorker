using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses.Pupil;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User
{
    public class GetPupilPersonalInfoQueryHandler : IRequestHandler<GetPupilPersonalInfoQuery, PupilPersonalInfoResponse>
    {
        private readonly IUserRepository _userRespository;
        private readonly IMapper _mapper;
        public GetPupilPersonalInfoQueryHandler(IUserRepository userRespository, IMapper mapper)
        {
            _userRespository = userRespository;
            _mapper = mapper;
        }
        public async Task<PupilPersonalInfoResponse> Handle(GetPupilPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var pupil = await _userRespository.GetUserByIdAsync(request.Id, cancellationToken);
            if (pupil == null)
            {
                throw new Exception("Pupil not found");
            }
            var pupilResponse = _mapper.Map<PupilPersonalInfoResponse>(pupil);
            return pupilResponse;
        }
    }
}
   


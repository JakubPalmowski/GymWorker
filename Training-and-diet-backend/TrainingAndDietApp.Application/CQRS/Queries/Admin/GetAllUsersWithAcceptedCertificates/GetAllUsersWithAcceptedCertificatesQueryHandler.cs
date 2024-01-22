using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllUsersWithAcceptedCertificates
{
    public class GetAllUsersWithAcceptedCertificatesQueryHandler : IRequestHandler<GetAllUsersWithAcceptedCertificatesQuery, List<GetAllUsersWithCertificatesResponse>>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public GetAllUsersWithAcceptedCertificatesQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllUsersWithCertificatesResponse>> Handle(GetAllUsersWithAcceptedCertificatesQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersWithCertificatesAsync(true,cancellationToken);
            return _mapper.Map<List<GetAllUsersWithCertificatesResponse>>(users);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllUsersWithPendingCertificates
{
    public class GetAllUsersWithPendingCertificatesQueryHandler : IRequestHandler<GetAllUsersWithPendingCertificatesQuery, List<GetAllUsersWithCertificatesResponse>>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public GetAllUsersWithPendingCertificatesQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

            
    public async Task<List<GetAllUsersWithCertificatesResponse>> Handle(GetAllUsersWithPendingCertificatesQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersWithCertificatesAsync(false,cancellationToken);
            return _mapper.Map<List<GetAllUsersWithCertificatesResponse>>(users);
        }
    }
}

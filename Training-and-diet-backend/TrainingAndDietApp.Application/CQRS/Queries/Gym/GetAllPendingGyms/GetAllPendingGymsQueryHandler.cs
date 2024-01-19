using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAllPendingGyms
{
    public class GetAllPendingGymsQueryHandler : IRequestHandler<GetAllPendingGymsQuery, List<GymAdminInfoResponse>>
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;

        public GetAllPendingGymsQueryHandler(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }
        public async Task<List<GymAdminInfoResponse>> Handle(GetAllPendingGymsQuery request, CancellationToken cancellationToken)
        {
            var pendingGyms = await _gymRepository.GetAllPendingGymsAsync(cancellationToken);
            var response = _mapper.Map<List<GymAdminInfoResponse>>(pendingGyms);
            return response;
        }
    }
}

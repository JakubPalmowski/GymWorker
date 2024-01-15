using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Queries.Gym;
using TrainingAndDietApp.Application.Responses.Gym;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Gym
{
    public class GetMentorActiveGymsQueryHandler : IRequestHandler<GetMentorActiveGymsQuery, List<ActiveGymResponse>>
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;

        public GetMentorActiveGymsQueryHandler(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }

        public async Task<List<ActiveGymResponse>> Handle(GetMentorActiveGymsQuery request, CancellationToken cancellationToken)
        {
            var gyms = await _gymRepository.GetMentorActiveGymsAsync(request.idMentor, cancellationToken);
            var gymsDto = _mapper.Map<List<ActiveGymResponse>>(gyms);
            return gymsDto;
        }
    }
}

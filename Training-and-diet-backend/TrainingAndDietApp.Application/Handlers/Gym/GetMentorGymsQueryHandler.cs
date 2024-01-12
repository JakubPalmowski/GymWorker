using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Queries.Gym;
using TrainingAndDietApp.Application.Responses.Gym;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Gym
{
    public class GetMentorGymsQueryHandler : IRequestHandler<GetMentorGymsQuery, List<GymResponse>>
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;

        public GetMentorGymsQueryHandler(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }

        public async Task<List<GymResponse>> Handle(GetMentorGymsQuery request, CancellationToken cancellationToken)
        {
            var gyms = await _gymRepository.GetMentorGymsAsync(request.idMentor, cancellationToken);
            var gymsDto = _mapper.Map<List<GymResponse>>(gyms);
            return gymsDto;
        }
    }
}

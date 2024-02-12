using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetMentorGyms
{
    public class GetMentorActiveGymsQueryHandler : IRequestHandler<GetMentorActiveGymsQuery, List<ActiveGymResponse>>
    {
        private IGymRepository _gymRepository;
        private IMapper _mapper;

        public GetMentorActiveGymsQueryHandler(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }

        public async Task<List<ActiveGymResponse>> Handle(GetMentorActiveGymsQuery request, CancellationToken cancellationToken)
        {
            var gyms = await _gymRepository.GetMentorActiveGymsAsync(request.idMentor, cancellationToken);
            if (!gyms.Any())
                throw new NotFoundException("Gym not found");

            var gymsResponse = _mapper.Map<List<ActiveGymResponse>>(gyms);
            return gymsResponse;
        }
    }
}

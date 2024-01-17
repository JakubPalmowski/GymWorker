using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Queries.Gym;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Gym
{
    public class GetAllGymsAddedByUserQueryHandler : IRequestHandler<GetAllGymsAddedByUserQuery, List<GymsAddedByUserResponse>>
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;

        public GetAllGymsAddedByUserQueryHandler(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }

        public async Task<List<GymsAddedByUserResponse>> Handle(GetAllGymsAddedByUserQuery request, CancellationToken cancellationToken)
        {
            var gyms = await _gymRepository.GetAllGymsAddedByUserAsync(request.idUser, cancellationToken);
            var gymsResponse = _mapper.Map<List<GymsAddedByUserResponse>>(gyms);
            return gymsResponse;
        }
         
    }
}

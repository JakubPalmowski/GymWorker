using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAllGymsAddedByUser
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
            if (!gyms.Any())
                throw new NotFoundException("Gym not found");
            var gymsResponse = _mapper.Map<List<GymsAddedByUserResponse>>(gyms);
            return gymsResponse;
        }
         
    }
}

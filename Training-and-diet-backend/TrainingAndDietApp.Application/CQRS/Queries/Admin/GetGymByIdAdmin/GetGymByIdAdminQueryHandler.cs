using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetGymByIdAdmin
{
    public class GetGymByIdAdminQueryHandler : IRequestHandler<GetGymByIdAdminQuery, GetGymByIdAdminQuery>
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;

        public GetGymByIdAdminQueryHandler(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }
        public async Task<GetGymByIdAdminQuery> Handle(GetGymByIdAdminQuery request, CancellationToken cancellationToken)
        {
            var gym = await _gymRepository.GetGymWithAddressByIdAsync(request.IdGym, cancellationToken);
            if (gym == null)
            {
                throw new NotFoundException("Gym not found");
            }
            var response = _mapper.Map<GetGymByIdAdminQuery>(gym);
            return response;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllGymsAdmin
{
    public class GetAllGymsAdminQueryHandler : IRequestHandler<GetAllGymsAdminQuery, List<GymAdminInfoResponse>>
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;

        public GetAllGymsAdminQueryHandler(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }
        public async Task<List<GymAdminInfoResponse>> Handle(GetAllGymsAdminQuery request, CancellationToken cancellationToken)
        {
            if(request.status != "Pending" && request.status != "Active")
                throw new BadRequestException("Zły status");

            var pendingGyms=new List<Domain.Entities.Gym>();
            if (request.status == "Pending")
            {
                pendingGyms = await _gymRepository.GetAllGymsAdminAsync(Domain.Enums.Status.Pending, cancellationToken);
                
            }else if(request.status == "Active")
            {
                pendingGyms = await _gymRepository.GetAllGymsAdminAsync(Domain.Enums.Status.Active, cancellationToken);
                
            }
            var response = _mapper.Map<List<GymAdminInfoResponse>>(pendingGyms);
            return response;
        }
    }
}

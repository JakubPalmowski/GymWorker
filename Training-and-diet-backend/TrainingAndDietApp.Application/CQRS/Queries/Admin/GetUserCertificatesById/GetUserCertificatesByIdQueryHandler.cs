using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserCertificatesById
{
    public class GetUserCertificatesByIdQueryHandler : IRequestHandler<GetUserCertificatesByIdQuery, List<GetUserCertificatesByIdQuery>>
    {
        private readonly IRepository<Domain.Entities.User> _userBaseRepository;
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public GetUserCertificatesByIdQueryHandler(IRepository<Domain.Entities.User> userBaseRepository, IMapper mapper ,ICertificateRepository certificateRepository)
        {
            _userBaseRepository = userBaseRepository;
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }
        public async Task<List<GetUserCertificatesByIdQuery>> Handle(GetUserCertificatesByIdQuery request, CancellationToken cancellationToken)
        {
            
            var user = await _userBaseRepository.GetByIdAsync(request.IdMentor, cancellationToken);
            if (user == null)
                throw new NotFoundException("User not found");
            
            var userCertificates = await _certificateRepository.GetCertificatesFromUserAsync(request.IdMentor, cancellationToken);
            var userCertificatesDto  = _mapper.Map<List<GetUserCertificatesByIdQuery>>(userCertificates);
            return userCertificatesDto;
        }
    }
}

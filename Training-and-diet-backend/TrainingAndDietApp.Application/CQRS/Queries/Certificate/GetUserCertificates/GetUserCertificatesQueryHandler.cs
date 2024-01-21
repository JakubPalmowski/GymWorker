using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Certificate.GetUserCertificates
{
    public class GetUserCertificatesQueryHandler : IRequestHandler<GetUserCertificatesQuery, List<GetUserCertificatesQuery>>
    {
        private ICertificateRepository _certificateRepository;
        private IMapper _mapper;

        public GetUserCertificatesQueryHandler(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUserCertificatesQuery>> Handle(GetUserCertificatesQuery request, CancellationToken cancellationToken)
        {
            var certificates = await _certificateRepository.GetCertificatesFromUserAsync(request.IdMentor, cancellationToken);
            return _mapper.Map<List<GetUserCertificatesQuery>>(certificates);
        }
    }
}

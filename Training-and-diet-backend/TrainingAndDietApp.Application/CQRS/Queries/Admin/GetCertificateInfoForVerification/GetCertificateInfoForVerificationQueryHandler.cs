using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetCertificateInfoForVerification
{
    public class GetCertificateInfoForVerificationQueryHandler : IRequestHandler<GetCertificateInfoForVerificationQuery, CertificateVerificationResponse>
    {
        private readonly IRepository<Domain.Entities.Certificate> _certificateBaseRepository;
        private readonly IMapper _mapper;

        public GetCertificateInfoForVerificationQueryHandler(IRepository<Domain.Entities.Certificate> certificateBaseRepository, IMapper mapper)
        {
            _certificateBaseRepository = certificateBaseRepository;
            _mapper = mapper;
        }
        
        public async Task<CertificateVerificationResponse> Handle(GetCertificateInfoForVerificationQuery request, CancellationToken cancellationToken)
        {
            var certificate = await _certificateBaseRepository.GetByIdAsync(request.IdCertificate, cancellationToken);
            if (certificate == null)
                throw new NotFoundException("Certificate does not exist");

            var response = _mapper.Map<CertificateVerificationResponse>(certificate);
            return response;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyCertificate
{
    public class VerifyCertificateCommandHandler : IRequestHandler<VerifyCertificateCommand>
    {
        private readonly IRepository<Domain.Entities.Certificate> _certificateBaseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VerifyCertificateCommandHandler(IRepository<Domain.Entities.Certificate> certificateBaseRepository, IUnitOfWork unitOfWork)
        {
            _certificateBaseRepository = certificateBaseRepository;
            _unitOfWork = unitOfWork;
            
        }

        public async Task Handle(VerifyCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = await _certificateBaseRepository.GetByIdAsync(request.IdCertificate, cancellationToken);
            if (certificate == null)
                throw new NotFoundException("Certificate not found");
            
            if (certificate.IsAccepted)
                throw new BadRequestException("Certificate is already verified");
            
            certificate.IsAccepted = true;
            await _certificateBaseRepository.UpdateAsync(certificate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}

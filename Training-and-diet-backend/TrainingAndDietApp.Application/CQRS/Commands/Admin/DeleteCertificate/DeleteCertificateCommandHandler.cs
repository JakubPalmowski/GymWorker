using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteCertificate
{
    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand>
    {
        private readonly IRepository<Domain.Entities.Certificate> _certificateBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public DeleteCertificateCommandHandler(IRepository<Domain.Entities.Certificate> certificateBaseRepository, IUnitOfWork unitOfWork, IFileService fileService)
        {
            _certificateBaseRepository = certificateBaseRepository;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            
        }
        public async Task Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = await _certificateBaseRepository.GetByIdAsync(request.IdCertificate, cancellationToken);

            if (certificate == null)
                throw new NotFoundException("Certificate not found");
            
            var pdfUri = certificate.PdfUri;
            await _certificateBaseRepository.DeleteAsync(certificate.IdCertificate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            await _fileService.DeleteFileAsync(pdfUri);
        }
    }
}

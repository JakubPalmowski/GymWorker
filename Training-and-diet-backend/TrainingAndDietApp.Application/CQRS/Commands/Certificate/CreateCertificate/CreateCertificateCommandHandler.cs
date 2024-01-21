using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.Certificate;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Certificate.CreateCertificate
{
    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateInternalCommand ,CreateCertificateResponse>
    {
        private readonly IRepository<Domain.Entities.Certificate> _certificateBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Domain.Entities.User> _userBaseRepository;
        private readonly IFileService _fileService;

        public CreateCertificateCommandHandler(IFileService fileService,IRepository<Domain.Entities.User> userBaseRepository,IRepository<Domain.Entities.Certificate> certificateBaseRepository, IUnitOfWork unitOfWork)
        {
            _certificateBaseRepository = certificateBaseRepository;
            _unitOfWork = unitOfWork;
            _userBaseRepository = userBaseRepository;
            _fileService = fileService;
        }

        public async Task<CreateCertificateResponse> Handle(CreateCertificateInternalCommand request, CancellationToken cancellationToken)
        {
            var user = await _userBaseRepository.GetByIdAsync(request.IdMentor, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            try
            {
                var uniqueName = await _fileService.UploadPdfAsync(request.PdfFile);
                var certificate = new Domain.Entities.Certificate
                {
                    Description = request.CertificateCommand.Description,
                    IdMentor = request.IdMentor,
                    User = user,
                    PdfUri = uniqueName
                };
                await _certificateBaseRepository.AddAsync(certificate, cancellationToken);
                user.Certificates.Add(certificate);
                await _unitOfWork.CommitAsync(cancellationToken);

            }
            catch
            {
                throw;
            }
            return new CreateCertificateResponse
            {
                IsSuccess = true,
                Message = "Certificate created successfully"
            };
        }


        
    }
}

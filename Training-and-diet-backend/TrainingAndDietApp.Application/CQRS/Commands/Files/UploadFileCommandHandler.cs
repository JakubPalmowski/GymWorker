using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Files;

public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadFileResponse>
{
    private readonly IFileService _fileService;
    private readonly IRepository<Domain.Entities.User> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UploadFileCommandHandler(IFileService fileService, IRepository<Domain.Entities.User> repository, IUnitOfWork unitOfWork)
    {
        _fileService = fileService;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UploadFileResponse> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        /*var user = await _repository.GetByIdAsync(request.IdUser, cancellationToken);
        if (user == null)
            throw new NotFoundException("User not found");

        var fileUri = await _fileService.UploadFileAsync(request.File);
         = fileUri;
        _repository.UpdateAsync(user.Result, cancellationToken);
        _unitOfWork.CommitAsync(cancellationToken);

        return Task.FromResult(new UploadFileResponse
        {
            IsSuccess = true,
            FileUri = fileUri
        });*/

        return null;
    }
}
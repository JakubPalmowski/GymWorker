using System.Runtime.CompilerServices;
using MediatR;
using TrainingAndDietApp.Application.Abstractions.Files;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Files.Delete;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, bool>
{
    private readonly IFileService _fileService;
    private readonly IRepository<Domain.Entities.User> _baseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public DeleteFileCommandHandler(IFileService fileService, IUserRepository userRepository, IRepository<Domain.Entities.User> baseRepository, IUnitOfWork unitOfWork)
    {
        _fileService = fileService;
        _userRepository = userRepository;
        _baseRepository = baseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        var user = await _baseRepository.GetByIdAsync(request.LoggedUser, cancellationToken);
        if (user is null || user.ImageUri is null) 
            return false;
        var userWithGivenImage = await _userRepository.GetUserByImageUri(request.BlobFileName, cancellationToken);
        if (userWithGivenImage == null)
            return false;

        if(user.IdUser != userWithGivenImage.IdUser)
            return false;

        user.ImageUri = null;
        await _baseRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return await _fileService.DeleteFileAsync(request.BlobFileName);
    }
}
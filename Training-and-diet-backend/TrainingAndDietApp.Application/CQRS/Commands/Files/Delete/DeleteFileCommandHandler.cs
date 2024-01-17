using System.Runtime.CompilerServices;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Files.Delete;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, bool>
{
    private readonly IFileService _fileService;
    private readonly IRepository<Domain.Entities.User> _baseRepository;
    private readonly IUserRepository _userRepository;

    public DeleteFileCommandHandler(IFileService fileService, IUserRepository userRepository, IRepository<Domain.Entities.User> baseRepository)
    {
        _fileService = fileService;
        _userRepository = userRepository;
        _baseRepository = baseRepository;
    }

    public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        var user = await _baseRepository.GetByIdAsync(request.LoggedUser, cancellationToken);
        var userWithGivenImage = await _userRepository.GetUserByImageUri(request.BlobFileName, cancellationToken);

        if(user != null && userWithGivenImage != null && user.IdUser != userWithGivenImage.IdUser)
            return false;

        return await _fileService.DeleteFileAsync(request.BlobFileName);
    }
}
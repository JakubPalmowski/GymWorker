using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Commands.Files;
using TrainingAndDietApp.Application.Exceptions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Files.Download;

public class DownloadBlobQueryHandler : IRequestHandler<DownloadBlobQuery, BlobDto>
{
    private readonly IFileService _fileService;

    public DownloadBlobQueryHandler(IFileService fileService)
    {
        _fileService = fileService;
    }
    public async Task<BlobDto> Handle(DownloadBlobQuery request, CancellationToken cancellationToken)
    {
        var blob = await _fileService.DownloadAsync(request.BlobFileName);
        if (blob == null)
            throw new NotFoundException("File not found");
        return blob;
    }
}
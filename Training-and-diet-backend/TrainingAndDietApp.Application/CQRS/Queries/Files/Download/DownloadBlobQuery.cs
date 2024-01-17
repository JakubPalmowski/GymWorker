using MediatR;
using TrainingAndDietApp.Application.CQRS.Commands.Files;

namespace TrainingAndDietApp.Application.CQRS.Queries.Files.Download;

public class DownloadBlobQuery : IRequest<BlobDto>
{
    public DownloadBlobQuery(string blobFileName)
    {
        BlobFileName = blobFileName;
    }

    public string BlobFileName { get; set; }
}
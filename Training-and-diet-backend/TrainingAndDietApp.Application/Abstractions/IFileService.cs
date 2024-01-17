using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.CQRS.Commands.Files;

namespace TrainingAndDietApp.Application.Abstractions;

public interface IFileService
{
    Task<BlobDto?> DownloadAsync(string blobFileName);
    Task<string> UploadFileAsync(IFormFile file);
    Task<bool> DeleteFileAsync(string blobFileName);

}
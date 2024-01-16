using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.CQRS.Commands.Files;
using TrainingAndDietApp.Application.CQRS.Responses.Files;

namespace TrainingAndDietApp.Application.Abstractions;

public interface IFileService
{
    Task<List<BlobDto>> ListAsync();
    Task<BlobResponse> UploadAsync(IFormFile blob);
    Task<BlobDto?> DownloadAsync(string blobFileName);
    Task<string> UploadFileAsync(IFormFile file);

}
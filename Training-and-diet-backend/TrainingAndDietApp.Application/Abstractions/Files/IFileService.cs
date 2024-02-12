using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.CQRS.Commands.Files;

namespace TrainingAndDietApp.Application.Abstractions.Files;

public interface IFileService
{
    Task<BlobDto?> DownloadAsync(string blobFileName);
    Task<string> UploadPdfAsync(IFormFile file);
    Task<string> UploadImageAsync(IFormFile file);
    Task<bool> DeleteFileAsync(string blobFileName);

}
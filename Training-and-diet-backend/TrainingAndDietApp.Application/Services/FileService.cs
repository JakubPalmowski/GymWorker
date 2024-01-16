using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Commands.Files;
using TrainingAndDietApp.Application.CQRS.Responses.Files;

namespace TrainingAndDietApp.Application.Services;

public class FileService : IFileService
{

    private readonly string _storageAccount = "s22703";

    private readonly string _key =
        "VvCIsLVbmd9giiFZEzD1JEtWqGKg5tAATdek5Ba6hLrYVg7U3C6KAlEJkjF0VZGFv2eHnpR0aKVN+AStpv5A3w==";
    private readonly BlobContainerClient _filesContainer;



    public FileService()
    {
        var credential = new StorageSharedKeyCredential(_storageAccount, _key);
        var blobUri = new Uri($"https://{_storageAccount}.blob.core.windows.net");
        var blobServiceClient = new BlobServiceClient(blobUri, credential);
        _filesContainer = blobServiceClient.GetBlobContainerClient("files");
    }

    public async Task<List<BlobDto>> ListAsync()
    {
        List<BlobDto> files = new();
        await foreach (var file in _filesContainer.GetBlobsAsync())
        {
            string uri = _filesContainer.Uri.ToString();
            var name = file.Name;
            var fullUri = $"{uri}/{name}";

            files.Add(new BlobDto
            {
                Uri = fullUri,
                Name = name,
                ContentType = file.Properties.ContentType
            });
        }

        return files;
    }

    public async Task<BlobResponse> UploadAsync(IFormFile blob)
    {
        var response = new BlobResponse();
        BlobClient blobClient = _filesContainer.GetBlobClient(blob.FileName);

        await using (Stream? data = blob.OpenReadStream())
        {
            await blobClient.UploadAsync(data);
        }

        response.Status = $"File {blob.FileName} Uploaded Successfully";
        response.Error = false;
        response.Blob.Uri = blobClient.Uri.AbsoluteUri;
        response.Blob.Name = blobClient.Name;

        return response;
    }

    public async Task<BlobDto?> DownloadAsync(string blobFileName)
    {
        BlobClient blobClient = _filesContainer.GetBlobClient(blobFileName);

        if (await blobClient.ExistsAsync())
        {
            var data = await blobClient.OpenReadAsync();
            Stream blobContent = data;

            var content = await blobClient.DownloadContentAsync();
            string name = blobFileName;
            string contentType = content.Value.Details.ContentType;


            return new BlobDto
            {
                Content = blobContent,
                Name = name,
                ContentType = contentType
            };
            
        }
        return null;
    }
    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new Exception("File is empty");

        BlobClient blobClient = _filesContainer.GetBlobClient(file.FileName);
        using (Stream data = file.OpenReadStream())
        {
            await blobClient.UploadAsync(data);
        }
        return blobClient.Uri.AbsoluteUri; // Return the URI of the uploaded file
    }

}
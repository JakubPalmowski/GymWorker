﻿using Azure.Core;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Commands.Files;
using TrainingAndDietApp.Application.CQRS.Responses.Files;
using TrainingAndDietApp.Common.Exceptions;

namespace TrainingAndDietApp.Application.Services.Files;

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

    public async Task<BlobDto?> DownloadAsync(string blobFileName)
    {
        BlobClient blobClient = _filesContainer.GetBlobClient(blobFileName);

        if (!await blobClient.ExistsAsync()) return null;

        var data = await blobClient.OpenReadAsync();
        var blobContent = data;

        var content = await blobClient.DownloadContentAsync();
        var contentType = content.Value.Details.ContentType;


        return new BlobDto
        {
            Content = blobContent,
            Name = blobFileName,
            ContentType = contentType
        };
    }

    public async Task<string> UploadImageAsync(IFormFile file)
{
    if (!IsImage(file.FileName))
    {
        throw new BadRequestException("File is not an image.");
    }

    return await UploadFileAsync(file, GetContentType(file.FileName));
}

public async Task<string> UploadPdfAsync(IFormFile file)
{
    if (!IsPdf(file.FileName))
    {
        throw new BadRequestException("File is not a PDF.");
    }

    return await UploadFileAsync(file, GetContentType(file.FileName));
}

private async Task<string> UploadFileAsync(IFormFile file, string contentType)
{
    if (file == null || file.Length == 0)
        throw new Exception("File is empty");

    var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
    var blobClient = _filesContainer.GetBlobClient(uniqueFileName);

    var blobHttpHeaders = new BlobHttpHeaders { ContentType = contentType };

    using (var data = file.OpenReadStream())
    {
        await blobClient.UploadAsync(data, new BlobUploadOptions
        {
            HttpHeaders = blobHttpHeaders
        });
    }

    return uniqueFileName;
}

private bool IsImage(string fileName)
{
    var extension = Path.GetExtension(fileName).ToLowerInvariant();
    return extension == ".jpg" || extension == ".jpeg" || extension == ".png";
}

private bool IsPdf(string fileName)
{
    var extension = Path.GetExtension(fileName).ToLowerInvariant();
    return extension == ".pdf";
}

private string GetContentType(string fileName)
{
    var extension = Path.GetExtension(fileName).ToLowerInvariant();
    switch (extension)
    {
        case ".pdf":
            return "application/pdf";
        case ".jpg":
        case ".jpeg":
            return "image/jpeg";
        case ".png":
            return "image/png";
        default:
            return "application/octet-stream";
    }
}


    public async Task<bool> DeleteFileAsync(string blobFileName)
    {
        var blobClient = _filesContainer.GetBlobClient(blobFileName);
        if (!await blobClient.ExistsAsync()) return false;
        await blobClient.DeleteAsync();
        return true;
    }

}
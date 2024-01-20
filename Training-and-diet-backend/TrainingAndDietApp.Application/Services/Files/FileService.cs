﻿using Azure.Core;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Commands.Files;
using TrainingAndDietApp.Application.CQRS.Responses.Files;

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
    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new Exception("File is empty");
        var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var blobClient = _filesContainer.GetBlobClient(uniqueFileName);
        using (var data = file.OpenReadStream())
        {
            await blobClient.UploadAsync(data);
        }

        return uniqueFileName;
    }

    public async Task<bool> DeleteFileAsync(string blobFileName)
    {
        var blobClient = _filesContainer.GetBlobClient(blobFileName);
        if (!await blobClient.ExistsAsync()) return false;
        await blobClient.DeleteAsync();
        return true;
    }

}
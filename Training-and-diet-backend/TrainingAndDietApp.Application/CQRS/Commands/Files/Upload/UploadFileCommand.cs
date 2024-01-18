using MediatR;
using Microsoft.AspNetCore.Http;

namespace TrainingAndDietApp.Application.CQRS.Commands.Files.Upload;

public record UploadFileCommand(IFormFile File, int IdUser) : IRequest<UploadFileResponse>;

public class UploadFileResponse
{
    public bool IsSuccess { get; set; }
    public string FileUri { get; set; }
}


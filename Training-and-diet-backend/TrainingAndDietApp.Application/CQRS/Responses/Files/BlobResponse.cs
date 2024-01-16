using TrainingAndDietApp.Application.CQRS.Commands.Files;

namespace TrainingAndDietApp.Application.CQRS.Responses.Files;

public class BlobResponse
{
    public BlobResponse()
    {
        Blob = new BlobDto();
    }

    public string? Status { get; set; }
    public bool Error { get; set; }

    public BlobDto Blob { get; set; }
}
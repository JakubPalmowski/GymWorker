using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Files.Delete;

public record DeleteFileCommand(string BlobFileName, int LoggedUser) : IRequest<bool>;

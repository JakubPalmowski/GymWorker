﻿using MediatR;
using TrainingAndDietApp.Application.Abstractions.Files;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Files.Upload;

public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadFileResponse>
{
    private readonly IFileService _fileService;
    private readonly IRepository<Domain.Entities.User> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UploadFileCommandHandler(IFileService fileService, IRepository<Domain.Entities.User> repository, IUnitOfWork unitOfWork)
    {
        _fileService = fileService;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UploadFileResponse> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.IdUser, cancellationToken);
        if (user == null)
            throw new NotFoundException("User not found");
        try{
            if(user.ImageUri != null){
                await _fileService.DeleteFileAsync(user.ImageUri);
            }
            var uniqueName = await _fileService.UploadImageAsync(request.File);
            user.ImageUri = uniqueName;
            await _repository.UpdateAsync(user, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        } catch {
            throw;
        }

        return new UploadFileResponse
        {
            IsSuccess = true,
            FileUri = user.ImageUri
        };

    }
}
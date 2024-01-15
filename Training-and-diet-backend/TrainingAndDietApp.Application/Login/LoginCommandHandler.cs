using System.ComponentModel.DataAnnotations;
using MediatR;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _repository;

    public LoginCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
        {
            throw new BadRequestException("There is no user with ");
        }
    }
}
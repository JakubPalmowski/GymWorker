using MediatR;
using TrainingAndDietApp.Application.Commands.Auth.Register;

namespace TrainingAndDietApp.Application.Handlers.Auth.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    

    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
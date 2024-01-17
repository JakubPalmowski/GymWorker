using System.Runtime.CompilerServices;
using MediatR;
using Training_and_diet_backend.Data.Migrations;
using TrainingAndDietApp.Application.Abstractions.Auth;
using TrainingAndDietApp.Application.CQRS.Responses.Auth;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Auth.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginCommand, TokenResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IUserRepository _userRepository;
    private readonly IRepository<Domain.Entities.User> _baseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(ITokenService tokenService, IPasswordService passwordService, IUserRepository userRepository, IUnitOfWork unitOfWork, IRepository<Domain.Entities.User> baseRepository)
    {
        _tokenService = tokenService;
        _passwordService = passwordService;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _baseRepository = baseRepository;
    }

    public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailWithRoleAsync(request.Email, cancellationToken);
        if (user is null)
            throw new UnauthorizedException("");
        if (!_passwordService.VerifyPassword(request.Password, user.HashedPassword))
            throw new UnauthorizedException("");

        (string refreshToken, DateTime refreshTokenExpiration) = _tokenService.GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpirationDate = refreshTokenExpiration;

        await _baseRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        var accessToken = _tokenService.GenerateAccessToken(user);
        return new TokenResponse(accessToken, refreshToken);

    }
}
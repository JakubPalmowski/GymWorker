using MediatR;
using TrainingAndDietApp.Application.Abstractions.Auth;
using TrainingAndDietApp.Application.Commands.Auth.Refresh;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Responses.Auth;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Auth.Refresh;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IUserRepository _userRepository;
    private readonly IRepository<Domain.Entities.User> _baseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenCommandHandler(ITokenService tokenService, IPasswordService passwordService, IUserRepository userRepository, IRepository<Domain.Entities.User> baseRepository, IUnitOfWork unitOfWork)
    {
        _tokenService = tokenService;
        _passwordService = passwordService;
        _userRepository = userRepository;
        _baseRepository = baseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var idUser = _tokenService.VerifyAccessToken(request.AccessToken, false);
        if (idUser is null)
            throw new UnauthorizedException("");

        var user = await _userRepository.GetByIdWithRoleAsync(idUser.Value, cancellationToken);
        if (user is null || user.RefreshToken != request.RefreshToken)
            throw new UnauthorizedException("");

        if (user.RefreshTokenExpirationDate < DateTime.UtcNow)
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
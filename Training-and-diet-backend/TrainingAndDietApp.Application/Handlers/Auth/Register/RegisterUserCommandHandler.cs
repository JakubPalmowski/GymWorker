using AutoMapper;
using MediatR;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Abstractions.Auth;
using TrainingAndDietApp.Application.Commands.Auth.Register;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Responses.Auth;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Auth.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, TokenResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IUserRepository _userRepository;
    private readonly IRepository<Domain.Entities.User> _baseRepository;
    private readonly IRepository<Role> _roleRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public RegisterUserCommandHandler(ITokenService tokenService, IPasswordService passwordService, IUserRepository userRepository, IRepository<Domain.Entities.User> baseRepository, IUnitOfWork unitOfWork, IMapper mapper, IRepository<Role> roleRepository)
    {
        _tokenService = tokenService;
        _passwordService = passwordService;
        _userRepository = userRepository;
        _baseRepository = baseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<TokenResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailWithRoleAsync(request.Email, cancellationToken);
        if (user is not null)
            throw new ConflictException("User with given email already exists");

        var passwordHash = _passwordService.HashPassword(request.Password);
        var userToAdd = _mapper.Map<Domain.Entities.User>(request);

        userToAdd.HashedPassword = passwordHash;

        var role = await _roleRepository.GetByIdAsync(request.RoleId, cancellationToken);
        if(role is null)
            throw new NotFoundException("Role with given id does not exist");
        userToAdd.Role = role;

        await _baseRepository.AddAsync(userToAdd, cancellationToken);
        var success = await _unitOfWork.CommitAsync(cancellationToken);

        if (success != 1)
            throw new ConflictException("User could not be added");

        (string refreshToken, DateTime refreshTokenExpirationDate) = _tokenService.GenerateRefreshToken();
        userToAdd.RefreshToken = refreshToken;
        userToAdd.RefreshTokenExpirationDate = refreshTokenExpirationDate;

        await _baseRepository.UpdateAsync(userToAdd, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        var accessToken = _tokenService.GenerateAccessToken(userToAdd);
        
        return new TokenResponse(accessToken, refreshToken);

    }
}
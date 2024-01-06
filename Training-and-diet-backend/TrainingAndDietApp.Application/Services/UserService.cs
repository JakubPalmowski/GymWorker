using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> CheckIfUserExists(int idUser, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(idUser, cancellationToken);
        return user != null;
    }

    public async Task<bool> CheckIfUserIsDietician(int dieticianId, CancellationToken cancellationToken)
    {
        return await _userRepository
            .AnyAsync(user => user.IdUser == dieticianId && (user.Role.Name.Equals("Dietician") || user.Role.Name.Equals("Dietician-Trainer")));
    }

    public async Task<bool> CheckIfUserIsTrainer(int trainerId, CancellationToken cancellationToken)
    {
        return await _userRepository
            .AnyAsync(user => user.IdUser == trainerId && (user.Role.Name.Equals("Trainer") || user.Role.Name.Equals("Dietician-Trainer")));
    }

}
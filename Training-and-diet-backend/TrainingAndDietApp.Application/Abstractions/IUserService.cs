namespace TrainingAndDietApp.Application.Abstractions;

public interface IUserService
{
    Task<bool> CheckIfUserExists(int idUser, CancellationToken cancellationToken);
    Task<bool> CheckIfUserIsDietician(int dieticianId, CancellationToken cancellationToken);
    Task<bool> CheckIfUserIsTrainer(int trainerId, CancellationToken cancellationToken);
}
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Domain.Abstractions;
public interface ITrainerGymRepository
{
    Task DeleteAsync(TrainerGym trainerGym, CancellationToken cancellationToken);
    Task AddAsync(TrainerGym trainerGym, CancellationToken cancellationToken);
    Task<TrainerGym?> GetByIdAsync(int idUser, int idGym, CancellationToken cancellationToken);
}

using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IOpinionRepository
    {
        Task<Opinion?> GetPupilMentorOpinionAsync(int idPupil, int IdMentor, CancellationToken cancellation);
        Task DeleteOpinionAsync(Opinion opinion, CancellationToken cancellation);
       
    }
}
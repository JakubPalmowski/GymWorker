using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
public interface ICertificateRepository
{
Task<List<Certificate>> GetCertificatesFromUserAsync(int userId, CancellationToken cancellation);
   
}
}
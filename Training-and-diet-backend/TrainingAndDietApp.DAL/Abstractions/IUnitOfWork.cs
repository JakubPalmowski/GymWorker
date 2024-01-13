namespace TrainingAndDietApp.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
using Microsoft.EntityFrameworkCore.Storage;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _currentTransaction;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
      public void BeginTransaction()
    {
        if (_currentTransaction == null)
        {
            _currentTransaction = _context.Database.BeginTransaction();
        }
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default){
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null)
        {
            try
            {
                await _currentTransaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
                throw; 
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }


    public void Dispose()
    {
        if (_currentTransaction != null)
        {
            _currentTransaction.Dispose();
        }
        _context.Dispose();
    }


    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.RollbackAsync(cancellationToken);
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }
    }

 
}
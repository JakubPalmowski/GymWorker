using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Domain.Abstractions;

public interface IAddressRepository
{
    Task<Address?> CheckIfAddressExistsAsync(string city, string street, string postalCode, CancellationToken cancellation);
}
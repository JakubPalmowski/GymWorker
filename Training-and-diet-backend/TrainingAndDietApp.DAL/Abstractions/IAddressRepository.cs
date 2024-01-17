using Training_and_diet_backend.Models;

public interface IAddressRepository
{
    Task<Address?> CheckIfAddressExistsAsync(string city, string street, string postalCode, CancellationToken cancellation);
    Task AddAsync(Address address, CancellationToken cancellation);
}

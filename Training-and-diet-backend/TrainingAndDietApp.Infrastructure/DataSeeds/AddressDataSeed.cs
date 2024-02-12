using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class AddressDataSeed : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        var address = new Address { IdAddress = 1, City = "Warszawa", PostalCode = "02-222", Street = "Wołoska" };
        var address2 = new Address { IdAddress = 2, City = "Warszawa", PostalCode = "02-324", Street = "Złota" };
        var address3 = new Address { IdAddress = 3, City = "Warszawa", PostalCode = "02-421", Street = "Syta" };

        builder.HasData(address, address2, address3);
    }
}
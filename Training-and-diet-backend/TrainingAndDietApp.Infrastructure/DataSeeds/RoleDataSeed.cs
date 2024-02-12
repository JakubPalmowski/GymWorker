using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class RoleDataSeed : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role()
            {
                Id = 1,
                Name = "Admin"
            },
            new Role()
            {
                Id = 2,
                Name = "Pupil"
            },
            new Role()
            {
                Id = 3,
                Name = "Trainer"
            },
            new Role()
            {
                Id = 4,
                Name = "Dietician"
            },
            new Role()
            {
                Id = 5,
                Name = "Dietician-Trainer"
            });

    }
}
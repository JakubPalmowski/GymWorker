using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class GymDataSeed : IEntityTypeConfiguration<Gym>
{
    public void Configure(EntityTypeBuilder<Gym> builder)
    {
        var gym1 = new Gym {IdGym = 1, IdAddress = 1, Name = "McFit Wołoska", IsAccepted = true};
        var gym2 = new Gym {IdGym = 2, IdAddress = 2, Name = "CityFit Centrum", IsAccepted = true };
        var gym3 = new Gym {IdGym = 3, IdAddress = 3, Name = "CityFit Wilanów", IsAccepted = true };

        builder.HasData(gym1, gym2, gym3);
    }
}
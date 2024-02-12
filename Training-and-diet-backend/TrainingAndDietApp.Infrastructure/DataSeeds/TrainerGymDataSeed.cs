using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class TrainerGymDataSeed : IEntityTypeConfiguration<TrainerGym>
{
    public void Configure(EntityTypeBuilder<TrainerGym> builder)
    {
        var trainerGym1 = new TrainerGym { IdTrainer = 1, IdGym = 1};
        var trainerGym2 = new TrainerGym { IdTrainer = 2, IdGym = 1};

        builder.HasData(trainerGym1, trainerGym2);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class TrainerGymDataSeed : IEntityTypeConfiguration<TrainerGym>
{
    public void Configure(EntityTypeBuilder<TrainerGym> builder)
    {
        var trainerGym1 = new TrainerGym { IdTrainer = 1, IdGym = 1};
        var trainerGym7 = new TrainerGym { IdTrainer = 1, IdGym = 2};
        var trainerGym8 = new TrainerGym { IdTrainer = 1, IdGym = 3};
        var trainerGym2 = new TrainerGym { IdTrainer = 2, IdGym = 1};
        var trainerGym3 = new TrainerGym { IdTrainer = 3, IdGym = 1};
        var trainerGym4 = new TrainerGym { IdTrainer = 18, IdGym = 1};
        var trainerGym5 = new TrainerGym { IdTrainer = 16, IdGym = 3};
        var trainerGym6 = new TrainerGym { IdTrainer = 15, IdGym = 1};

        builder.HasData(trainerGym1, trainerGym2,trainerGym3,trainerGym4,trainerGym5,trainerGym6,trainerGym7,trainerGym8);
    }
}
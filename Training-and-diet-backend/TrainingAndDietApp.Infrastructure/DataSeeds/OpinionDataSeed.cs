using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class OpinionDataSeed : IEntityTypeConfiguration<Opinion>
{
    public void Configure(EntityTypeBuilder<Opinion> builder)
    {
        var opinions = new List<Opinion>
        {
            new Opinion
            {
                IdPupil = 1,
                IdMentor = 2,
                Content = "Bardzo profesjonalne podejście do treningu. Czułem się zmotywowany i wspierany przez cały czas. Zdecydowanie polecam tego mentora!",
                OpinionDate = DateTime.UtcNow,
                Rate = 4.5m
            },
            new Opinion
            {
                IdPupil = 3,
                IdMentor = 4,
                Content = "Podejście mentora do diety i treningu przekroczyło moje oczekiwania. Indywidualnie dopasowany plan i ciągła motywacja dały świetne wyniki.",
                OpinionDate = DateTime.UtcNow,
                Rate = 5.0m
            },
            new Opinion
            {
                IdPupil = 2,
                IdMentor = 3,
                Content = "Trener jest bardzo zaangażowany i posiada ogromną wiedzę. Udało mi się osiągnąć cele, o których wcześniej mogłem tylko marzyć. Polecam z całego serca!",
                OpinionDate = DateTime.UtcNow,
                Rate = 4.8m
            }
        };
        builder.HasData(opinions);
    }
}
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
                IdPupil = 19,
                IdMentor = 1,
                Content = "Bardzo profesjonalne podejście do treningu. Czułem się zmotywowany i wspierany przez cały czas. Zdecydowanie polecam tego mentora!",
                OpinionDate = DateTime.UtcNow,
                Rate = 4.0m
            },
            new Opinion
            {
                IdPupil = 20,
                IdMentor = 1,
                Content = "Podejście mentora do diety i treningu przekroczyło moje oczekiwania. Indywidualnie dopasowany plan i ciągła motywacja dały świetne wyniki.",
                OpinionDate = DateTime.UtcNow,
                Rate = 5.0m
            },
            new Opinion
            {
                IdPupil = 21,
                IdMentor = 1,
                Content = "Trener jest bardzo zaangażowany i posiada ogromną wiedzę. Udało mi się osiągnąć cele, o których wcześniej mogłem tylko marzyć. Polecam z całego serca!",
                OpinionDate = DateTime.UtcNow,
                Rate = 5.0m
            },
            new Opinion
            {
                IdPupil = 19,
                IdMentor = 10,
                Content = "Zmiana diety zalecona przez dietetyka znacząco poprawiła moje samopoczucie i wyniki w sporcie. Profesjonalizm i indywidualne podejście do moich potrzeb żywieniowych zrobiły na mnie ogromne wrażenie.",
                OpinionDate = DateTime.UtcNow,
                Rate = 5.0m
            },
            new Opinion
            {
                IdPupil = 20,
                IdMentor = 8,
                Content = "Dzięki wskazówkom dietetyka udało mi się nie tylko schudnąć, ale też nauczyłem się, jak zdrowo się odżywiać na co dzień. Bardzo doceniam dostosowanie planu diety do mojego intensywnego trybu życia.",
                OpinionDate = DateTime.UtcNow,
                Rate = 5.0m
            },
            new Opinion
            {
                IdPupil = 21,
                IdMentor = 9,
                Content = "Dietetyk pomógł mi zrozumieć, jak ważna jest dieta w moim treningu. Jego/jej wsparcie i motywacja były nieocenione w drodze do osiągnięcia moich celów zdrowotnych. Absolutnie polecam!",
                OpinionDate = DateTime.UtcNow,
                Rate = 4.0m
            }
        };
        builder.HasData(opinions);
    }
}
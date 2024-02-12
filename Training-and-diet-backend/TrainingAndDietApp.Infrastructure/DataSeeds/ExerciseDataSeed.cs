using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class ExerciseDataSeed : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        var exercises = new List<Exercise>
        {
            new Exercise
            {
                IdExercise = 1,
                Name = "Przysiady",
                Details = "Ćwiczenie na nogi i pośladki",
                ExerciseSteps =
                    "Stań prosto z nogami rozstawionymi na szerokość barków. Powoli zginaj kolana, zachowując prosty kręgosłup. Schodź do momentu, aż uda będą równolegle do podłogi. Wróć do pozycji wyjściowej.",
                IdTrainer = null
            },
            new Exercise
            {
                IdExercise = 2,
                Name = "Pompki",
                Details = "Ćwiczenie na klatkę piersiową, ramiona i tricepsy",
                ExerciseSteps =
                    "Połóż dłonie na podłodze na szerokość barków. Utrzymaj ciało w prostej linii i opuszczaj się, zginając łokcie, aż klatka piersiowa prawie dotknie podłogi. Wróć do pozycji wyjściowej.",
                IdTrainer = null
            },
            new Exercise
            {
                IdExercise = 3,
                Name = "Brzuszki",
                Details = "Ćwiczenie na mięśnie brzucha",
                ExerciseSteps =
                    "Połóż się na plecach, zegnij kolana i postaw stopy na podłodze. Połóż dłonie za głową. Powoli podnosz tułów do kolan, a następnie powoli opuszczaj się z powrotem.",
                IdTrainer = null
            },
            new Exercise
            {
                IdExercise = 4,
                Name = "Martwy ciąg",
                Details = "Ćwiczenie na dolną część pleców, nogi i pośladki",
                ExerciseSteps =
                    "Stań prosto trzymając sztangę przed sobą. Zginaj biodra i kolana, opuszczając sztangę w dół, aż do momentu, gdy znajdzie się na wysokości goleni. Wróć do pozycji wyjściowej, prostując nogi i biodra.",
                IdTrainer = null
            },
            new Exercise
            {
                IdExercise = 5,
                Name = "Wiosłowanie sztangą",
                Details = "Ćwiczenie na górne partie pleców",
                ExerciseSteps =
                    "Stań z sztangą trzymaną w obu dłoniach. Pochyl się w biodrach, utrzymując lekki zgięcie w kolanach. Ciągnij sztangę do dolnej części klatki piersiowej, ściągając łopatki. Powoli opuść sztangę z powrotem.",
                IdTrainer = null
            }
           
        };
        builder.HasData(exercises);
    }
}
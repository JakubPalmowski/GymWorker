using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class CertificateDataSeed : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        var certificates = new List<Certificate>
        {
            new Certificate
            {
                IdCertificate = 1,
                PdfUri = "",
                Description = "Certyfikat ukończenia kursu trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 1
            },
            new Certificate
            {
                IdCertificate = 2,
                PdfUri = "",
                Description = "Certyfikat dietetyka klinicznego z akredytacją.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 2
            },
            new Certificate
            {
                IdCertificate = 3,
                PdfUri = "",
                Description = "Certyfikat zaawansowanego instruktora fitness.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = false,
                IdMentor = 3
            },
            new Certificate
            {
                IdCertificate = 4,
                PdfUri = "",
                Description = "Certyfikat ukończenia specjalistycznego kursu Pilates.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 4
            }
        };
        builder.HasData(certificates);
    }
}
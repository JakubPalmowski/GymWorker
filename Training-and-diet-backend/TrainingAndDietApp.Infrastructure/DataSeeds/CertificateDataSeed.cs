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
                PdfUri = "febb6cb4-3805-499d-b776-ff493aa35a14.pdf",
                Description = "Certyfikat trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 1
            },
            new Certificate
            {
                IdCertificate = 2,
                PdfUri = "03f34030-4c42-4f13-935b-35b95963e167.pdf",
                Description = "Certyfikat trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 2
            },
            new Certificate
            {
                IdCertificate = 3,
                PdfUri = "f8b22ef7-24d4-4ef5-95be-47a1c83479c5.pdf",
                Description = "Certyfikat trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = false,
                IdMentor = 3
            },
            new Certificate
            {
                IdCertificate = 4,
                PdfUri = "ab05466b-6a0d-4353-8fd3-03beb4ff53c0.pdf",
                Description = "Certyfikat trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 4
            },
            new Certificate
            {
                IdCertificate = 5,
                PdfUri = "a811d65d-ea91-4981-ac23-dfd020f888f0.pdf",
                Description = "Certyfikat trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 5
            },
            new Certificate
            {
                IdCertificate = 6,
                PdfUri = "5ce15f47-5af6-48e1-a995-8163e365f989.pdf",
                Description = "Certyfikat trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 6
            },
            new Certificate
            {
                IdCertificate = 7,
                PdfUri = "b8516244-c04b-408f-8825-ceed297744a2.pdf",
                Description = "Certyfikat zaawansowanego instruktora fitness.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = false,
                IdMentor = 7
            },
            new Certificate
            {
                IdCertificate = 8,
                PdfUri = "5a986774-64a5-48ff-93a9-908eedeebb65.pdf",
                Description = "Certyfikat ukończenia specjalistycznego kursu Pilates.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 8
            },
            new Certificate
            {
                IdCertificate = 9,
                PdfUri = "03a23944-7156-46ac-8a74-2e918e511d12.pdf",
                Description = "Certyfikat ukończenia kursu trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 9
            },
            new Certificate
            {
                IdCertificate = 10,
                PdfUri = "1fa0350a-3d69-4eb5-807c-096983c9f35d.pdf",
                Description = "Certyfikat dietetyka klinicznego z akredytacją.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 10
            },
            new Certificate
            {
                IdCertificate = 11,
                PdfUri = "fb6e1e39-8404-4095-a2ce-4f47a870e723.pdf",
                Description = "Certyfikat zaawansowanego instruktora fitness.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = false,
                IdMentor = 11
            },
            new Certificate
            {
                IdCertificate = 12,
                PdfUri = "6eb77e22-90ae-46d0-a5be-378a5da63c74.pdf",
                Description = "Certyfikat ukończenia specjalistycznego kursu Pilates.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 12
            },
            new Certificate
            {
                IdCertificate = 13,
                PdfUri = "594982e8-d080-4098-9ff4-f857997ac4d6.pdf",
                Description = "Certyfikat ukończenia kursu trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 13
            },
            new Certificate
            {
                IdCertificate = 14,
                PdfUri = "0243ab80-01d3-4407-98ee-9019cbd621cd.pdf",
                Description = "Certyfikat dietetyka klinicznego z akredytacją.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 14
            },
            new Certificate
            {
                IdCertificate = 15,
                PdfUri = "b32cfec6-95c3-4d62-a9a5-3e8eeac16b01.pdf",
                Description = "Certyfikat zaawansowanego instruktora fitness.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = false,
                IdMentor = 15
            },
            new Certificate
            {
                IdCertificate = 16,
                PdfUri = "98a5f8aa-2371-46b7-944f-36962f8470ac.pdf",
                Description = "Certyfikat ukończenia specjalistycznego kursu Pilates.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 16
            },
            new Certificate
            {
                IdCertificate = 17,
                PdfUri = "3da44fad-5888-44c9-a716-a5dff7875ff7.pdf",
                Description = "Certyfikat ukończenia kursu trenera personalnego.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 17
            },
            new Certificate
            {
                IdCertificate = 18,
                PdfUri = "715b3582-14eb-45e8-a33d-6cf8ff679364.pdf",
                Description = "Certyfikat dietetyka klinicznego z akredytacją.",
                AddedDate = DateTime.UtcNow,
                IsAccepted = true,
                IdMentor = 18
            }
        };
        builder.HasData(certificates);
    }
}
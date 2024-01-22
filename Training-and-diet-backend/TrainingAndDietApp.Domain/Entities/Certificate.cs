using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingAndDietApp.Domain.Entities
{
    public class Certificate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdCertificate { get; set; }
        public string PdfUri { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public bool IsAccepted { get; set; } = false;

        [ForeignKey("User")]
        public int IdMentor { get; set; }
        public virtual User User { get; set; }
    }
}

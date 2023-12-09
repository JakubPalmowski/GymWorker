using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;

namespace Training_and_diet_backend.Models
{
    public class Opinion
    {
        [ForeignKey("Pupil")]
        public int Id_Pupil { get; set; }

        [ForeignKey("Mentor")]
        public int Id_Mentor { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Content { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Opinion_date { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public decimal Rate { get; set; }
        public virtual User Mentor { get; set; }

        public virtual User Pupil { get; set; }
    }
}

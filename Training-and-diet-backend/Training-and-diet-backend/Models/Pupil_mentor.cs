using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Pupil_mentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        [ForeignKey("Mentor")]
        public int Id_Mentor { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        [ForeignKey("Pupil")]
        public int Id_Pupil { get; set; }

        public virtual User Mentor { get; set; }

        public virtual User Pupil { get; set; }
    }
}

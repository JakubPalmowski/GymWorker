using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Training_and_diet_backend.Models
{
    public class Trainee_exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Trainee_exercise { get; set; }
        public int Series_number { get; set; }
        public int Repetitions_number { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Comments { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public TimeSpan Exercise_duration { get; set; }
        [ForeignKey("Exercise")]
        public int Id_Exercise { get; set; }
        [ForeignKey("Training_plan")]
        public int Id_Training_plan { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual Training_plan Training_plan { get; set; }
    }
}

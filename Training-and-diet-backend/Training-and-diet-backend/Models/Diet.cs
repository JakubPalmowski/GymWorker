using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Diet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Diet { get; set; }
        [Required]
        public int Id_Dietician { get; set; }
        [Required]
        public int Id_Pupil { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Start_Date { get; set; }
        [Column(TypeName = "Date")]
        public DateTime End_Date { get; set; }
        public string DietDuration { get; set; }
        public int Total_kcal { get; set; }

        [ForeignKey("Id_Dietician")]
        public virtual User Dietician { get; set; }
        [ForeignKey("Id_Pupil")]
        public virtual User Pupil { get; set; }

        public virtual ICollection<Meal_Diet> MealsInDiet { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class Meal_Diet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_Meal_Diet { get; set; }
     
        public int Id_Meal { get; set; }
    
        public int Id_Diet { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Comments { get; set; }
        [ForeignKey("Id_Meal")]
        public virtual Meal Meal { get; set; }
        [ForeignKey("Id_Diet")]
        public virtual Diet Diet { get; set; }

       

    }
}

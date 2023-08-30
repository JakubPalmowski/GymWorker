using System.ComponentModel.DataAnnotations;

namespace Training_and_diet_backend.Models
{
    public class Exercise
    {
        [Key]
       public int Id_Excise { get; set; }
       public string Name { get; set; }
       public string Details { get; set; }
    }
}

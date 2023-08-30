using System.ComponentModel.DataAnnotations;

namespace Training_and_diet_backend.Models
{
    public class Excersice
    {
        [Key]
       public int Id_Excerise { get; set; }
       public string Name { get; set; }
       public string Details { get; set; }
    }
}

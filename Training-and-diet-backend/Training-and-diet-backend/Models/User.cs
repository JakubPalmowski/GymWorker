using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "char(11)")]
        public string Phone_number { get; set; }
        public bool Email_validated { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal? Height { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Sex { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Bio { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal? Training_plan_price_from { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? Training_plan_price_to { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? Personal_training_price_from { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? Personal_training_price_to { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? Diet_price_from { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal? Diet_price_to { get; set; }


        [InverseProperty("Pupil")]
        public virtual ICollection<Training_plan> Pupil_Training_plans { get; set; }
        [InverseProperty("Trainer")]
        public virtual ICollection<Training_plan> Trainer_Training_plans { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }


        [InverseProperty("Pupil")]
        public virtual ICollection<Pupil_mentor> Pupil_Mentors { get; set; }
        [InverseProperty("Mentor")]
        public virtual ICollection<Pupil_mentor> Mentor_Pupils { get; set; }
        public virtual ICollection<Diet> DietsAsDietician { get; set; }
        public virtual ICollection<Diet> DietsAsPupil { get; set; }

        [ForeignKey("Id_Role")]
        public virtual Role Role { get; set; }

        public int Id_Role { get; set; }

        [InverseProperty("Mentor")]
        public virtual ICollection<Opinion> Mentor_Opinions { get; set; }

        [InverseProperty("Pupil")]
        public virtual ICollection<Opinion> Pupil_Opinions { get; set; }

        public virtual ICollection<Trainer_Gym> Trainer_Gyms { get; set; }


    }
}

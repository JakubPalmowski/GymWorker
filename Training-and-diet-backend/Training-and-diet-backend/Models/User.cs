﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id_User { get; set; }
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }

        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "char(11)")]
        public string Phone_number { get; set; }
        public bool Email_validated { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public  decimal? Weight { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal? Height { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Sex { get; set; }

       

    }
}

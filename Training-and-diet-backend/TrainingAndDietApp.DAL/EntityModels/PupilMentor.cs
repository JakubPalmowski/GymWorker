﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    public class PupilMentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        [ForeignKey("Mentor")]
        public int IdMentor { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        [ForeignKey("Pupil")]
        public int IdPupil { get; set; }

        public virtual User Mentor { get; set; }

        public virtual User Pupil { get; set; }
    }
}
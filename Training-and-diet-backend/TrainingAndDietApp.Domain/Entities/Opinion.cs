﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrainingAndDietApp.Domain.Entities
{
    [Table("Opinion")]
    public class Opinion
    {

        [ForeignKey("Pupil")]
        public int IdPupil { get; set; }

        [ForeignKey("Mentor")]
        public int IdMentor { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Content { get; set; }

        [Column(TypeName = "Date")]
        public DateTime OpinionDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(2,1)")]
        public decimal Rate { get; set; }
        public virtual User Mentor { get; set; }

        public virtual User Pupil { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training_and_diet_backend.Models
{
    [Table("TrainingPlan")]
    public class TrainingPlanEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int IdTrainingPlan { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Type { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        public int? PlanDuration { get; private set; }

        [ForeignKey("Trainer")]
        public int IdTrainer { get; set; }
        [ForeignKey("Pupil")]
        public int? IdPupil { get; set; }

        public virtual UserEntity Trainer { get; set; }

        public virtual UserEntity Pupil { get; set; }

        public virtual ICollection<TraineeExerciseEntity> TraineeExercises { get; set; }


        public void CalculatePlanDuration()
        {
            PlanDuration = (EndDate - StartDate).Days;
        }
    }
}
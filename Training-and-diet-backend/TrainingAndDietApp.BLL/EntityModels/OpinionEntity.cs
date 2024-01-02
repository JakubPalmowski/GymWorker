using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.BLL.EntityModels;

namespace TrainingAndDietApp.BLL.Models
{
    public class OpinionEntity
    {
        public string Content { get; set; }
        public DateTime OpinionDate { get; set; }
        public decimal Rate { get; set; }
        public MentorEntity Mentor { get; set; }
        public virtual PupilEntity Pupil { get; set; }
    }
}
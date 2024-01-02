using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.BLL.Models
{
    public class TrainerGym
    {
        public int IdTrainerGym { get; set; }
        public Gym GymEntity { get; set; }
        public Trainer Trainer { get; set; }
    }
}

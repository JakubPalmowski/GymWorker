using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.BLL.EntityModels;

namespace TrainingAndDietApp.BLL.Models
{
    public class TrainerGymEntity
    {
        public int IdTrainerGym { get; set; }
        public GymEntity GymEntity { get; set; }
        public TrainerEntity TrainerEntity { get; set; }
    }
}

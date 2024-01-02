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
    public class GymEntity
    {
        public int IdGym { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; }
        public virtual ICollection<TrainerGymEntity> TrainerGyms { get; set; }
    }
}

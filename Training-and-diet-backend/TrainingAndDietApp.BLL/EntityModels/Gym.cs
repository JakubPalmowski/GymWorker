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
    public class Gym
    {
        public int IdGym { get; set; }
        public string Name { get; set; }

        public AddressValueObject AddressValueObject { get; set; }

        public virtual ICollection<TrainerGym> TrainerGyms { get; set; }
    }
}

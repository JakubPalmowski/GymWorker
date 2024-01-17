using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.Domain.Enums;

namespace TrainingAndDietApp.Application.CQRS.Responses.Gym
{
    public class ActiveGymResponse
    {
        public int IdGym { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
    }
}

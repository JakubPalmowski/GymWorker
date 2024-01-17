using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Application.CQRS.Responses.Gym
{
    public class GymResponse
    {
        public string Name { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; }
    }
}
